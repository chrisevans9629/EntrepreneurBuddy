<style scoped>
  .card {
    border: 1px #efefef solid;
    transition-timing-function: ease-in;
    transition-property: box-shadow;
    transition-duration: .1s;
    transition-timing-function: linear;
    text-align: left;
    padding: 10px;
    background-color: #F5F4F4;
    border-radius: 15px;
    width: 100%;
  }

  .button {
    background-color: #24305e;
    -moz-border-radius: 17px;
    -webkit-border-radius: 17px;
    border-radius: 17px;
    display: inline-block;
    cursor: pointer;
    color: #fff;
    font-family: Arial;
    font-size: 17px;
    font-weight: bold;
    padding: 5px 10px;
    text-decoration: none;
    line-height: 30px;
  }

  .button-light {
    background-color: #91b3be;
    -moz-border-radius: 17px;
    -webkit-border-radius: 17px;
    border-radius: 17px;
    display: inline-block;
    cursor: pointer;
    color: #fff;
    font-family: Arial;
    font-size: 17px;
    font-weight: bold;
    /* padding: 5px 5px; */
    text-decoration: none;
    line-height: 30px;
  }

  .chevron-down {
    height: 20px;
  }

  .bg-white {
    background-color: white;
    border-radius: 15px;
  }


  .check {
    height: 30px;
  }
</style>


<template>
  <div class="card shadow-sm ">
    <div class="m-2">
      <p><b> {{request.request.topic}}</b></p>
      <div class="row text-left name-color" style="padding:10px 10px;">

        <img src="/images/chevron-down.png" class="chevron-down mr-4 mt-2" v-if="request.emails" v-show="!emailsShowing" @click="showEmails">
        <img src="/images/chevron-up.png" class="chevron-down mr-4 mt-2" v-if="request.emails" v-show="emailsShowing" @click="showEmails">
        <div>
          <h3 class="text-left mr-3">{{request.attendCount}} interested</h3>
        </div>

        <a href="javascript:void(0)" class="button-light text-left" @click="joinHelpRequest()" v-if="ismentor=='False' && request.isJoined != true"> + Join</a>
        <div v-if="ismentor=='False' && request.isJoined == true">
          <img src="/images/check.png" class="check">

        </div>

        <div class="black-text mt-3 bg-white p-4 text-left" v-if="emailsShowing">
          <a href="javascript:void(0)" class="button-light mb-2" @click="copyEmails()" v-if="ismentor=='True' && currentMentor != null && currentMentor.id == request.request.mentorId && emailsShowing"> {{copy}}</a>
          <div v-for="email in request.emails">
            {{email}}
          </div>
        </div>

        <div class=" text-center mt-3">
          <a href="javascript:void(0)" class="button-light" @click="completeHelpRequest()" v-if="ismentor=='True' && currentMentor != null && currentMentor.id == request.request.mentorId"> Complete</a>
        </div>
      </div>


    </div>


    <modal name="confirm-modal">
      <div class="m-5 text-center">
        <p class="text-center">You have been added to this help request!</p>
        <button type="button" class="button" @click="closeModal">
          OK!
        </button>
      </div>
    </modal>
  </div>

</template>

<script>
  import axios from 'axios';

  export default {
    name: 'RequestCard',
    data: () => ({
      emailsShowing: false,
      copy: 'Copy'
    }),

    props: {
      request: {
        type: Object,
        default: () => { }
      }, ismentor: {
        type: String,
        default: 'False'
      }, getMentoringRequests: {
        type: Function,
        default: () => { }
      }, currentMentor: {
        type: Object,
        default: () => { }
      }
    },


    methods: {
      async joinHelpRequest() {
        await axios.post('/api/Entrepenuers/Join/' + this.request.request.id);
        this.request.attendCount++;
        this.request.isJoined = true;
        this.$modal.show('confirm-modal');
      },
      async completeHelpRequest() {
        await axios.delete('/api/MentoringRequests/' + this.request.request.id);
        this.getMentoringRequests();
      },
      async closeModal() {
        this.$modal.hide('confirm-modal');
      },
      copyEmails() {
        var str = this.request.emails.reduce(function reduceFunc(result, value) { return result + ';' + value; });
        const el = document.createElement('textarea');
        el.value = str;
        document.body.appendChild(el);
        el.select();
        document.execCommand('copy');
        document.body.removeChild(el);
        this.copy = 'Copied!';
      },

      async showEmails() {
        this.emailsShowing = !this.emailsShowing;
        //if (this.showEmails) {
        //    this.showEmails = false
        //}
        //else {
        //    this.showEmails = true
        //}
      }
    },



  }

</script>