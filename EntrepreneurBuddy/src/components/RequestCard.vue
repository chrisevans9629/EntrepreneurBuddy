<style scoped>
  .button {
    background-color: #24305E;
    -moz-border-radius: 17px;
    -webkit-border-radius: 17px;
    border-radius: 17px;
    display: inline-block;
    cursor: pointer;
    color: #000000;
    font-family: Arial;
    font-size: 17px;
    font-weight: bold;
    padding: 10px 10px;
    text-decoration: none;
  }

  .button:hover {
    background-color: #91B3BE;
  }

  .button:active {
    position: relative;
    top: 1px;
  }

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
      <p><b>Request:</b> {{request.topic}}</p>
      <div class="row" style="padding:10px 10px;">
        <h3>{{request.attendCount}}</h3>
        <div style="padding:0px 30px" />
        <a href="#" class="button" @click="joinSession()">+ Help Request</a>
      </div>

    </div>
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
      async joinSession() {
        const { data } = await axios.put('/api/MentoringRequests/join?requestid=' + this.request.id);
        this.request = data;
      }
    },

  }

</script>