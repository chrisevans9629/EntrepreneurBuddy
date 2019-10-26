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
</style>


<template>
  <div class="card shadow-sm ">
    <div class="m-2">
      <p><b>Request:</b> {{request.request.topic}}</p>
      <div class="row" style="padding:10px 10px;">
        <h3>{{request.attendCount}}</h3>
        <div style="padding:0px 30px" />
        <a href="javascript:void(0)" class="button" @click="joinHelpRequest()"> Join Help Request</a>
      </div>

    </div>
    <modal name="confirm-modal">
      <p>You have been added to this help request!</p>
      <button type="button" class="button" @click="closeModal">
        OK!
      </button>
    </modal>
  </div>

</template>

<script>
  import axios from 'axios';

  export default {
    name: 'RequestCard',
    props: {
      request: {
        type: Object,
        default: () => { }
      },
    },


    methods: {
      async joinHelpRequest() {
        await axios.post('/api/Entrepenuers/Join/' + this.request.request.id);
        this.request.attendCount++;
        this.$modal.show('confirm-modal');
      },

      async closeModal() {
        this.$modal.hide('confirm-modal');
      }
    },



  }

</script>