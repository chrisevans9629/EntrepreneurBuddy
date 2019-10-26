<style scoped>
  .button {
    background-color: #64CC96;
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
    background-color: #C8F2DC;
  }

  .button:active {
    position: relative;
    top: 1px;
  }

  .mentor-card {
    border: 1px #efefef solid;
    -webkit-box-shadow: 10px 10px 10px -2px rgba(219, 219, 219, 1);
    -moz-box-shadow: 10px 10px 10px -2px rgba(219, 219, 219, 1);
    box-shadow: 10px 10px 10px -2px rgba(219, 219, 219, 1);
    transition-timing-function: ease-in;
    transition-property: box-shadow;
    transition-duration: .1s;
    transition-timing-function: linear;
    text-align: left;
    -webkit-text-fill-color: black;

  }

  img {
    max-width: 100%;

  }

  .round-card {
    border-radius: 3px;
    overflow: hidden;
  }

  .mentor-card:hover {
    -webkit-box-shadow: 15px 15px 15px -2px rgba(219, 219, 219, 1);
    -moz-box-shadow: 15px 15px 15px -2px rgba(219, 219, 219, 1);
    box-shadow: 15px 15px 15px -2px rgba(219, 219, 219, 1);

  }
</style>

<template>
  <div class="mentor-card" :class="{'round-card':rounded}">
    <img :src="mentor.imageUrl">
    <div class="ml-3 mt-3">
      <p>{{mentor.firstName}} {{mentor.lastName}}</p>
      <p>{{mentor.skills}}</p>
      <a :href="'/home/mentoringrequests/'+mentor.id" class="button">Request Help</a>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'MentorCard',
    props: {
      mentor: {
        type: Object,
        default: () => { }
      },
      rounded: Boolean,
    }
  }

</script>

<style scoped>
  .mentor-card {
    border: 1px #efefef solid;
    -webkit-box-shadow: 10px 10px 10px -2px rgba(219, 219, 219, 1);
    -moz-box-shadow: 10px 10px 10px -2px rgba(219, 219, 219, 1);
    box-shadow: 10px 10px 10px -2px rgba(219, 219, 219, 1);
    transition-timing-function: ease-in;
    transition-property: box-shadow;
    transition-duration: .1s;
    transition-timing-function: linear;
    text-align: left;
    -webkit-text-fill-color: black;

  }

  img {
    max-width: 100%;

  }

  .round-card {
    border-radius: 3px;
    overflow: hidden;
  }

  .l-card:hover {
    -webkit-box-shadow: 15px 15px 15px -2px rgba(219, 219, 219, 1);
    -moz-box-shadow: 15px 15px 15px -2px rgba(219, 219, 219, 1);
    box-shadow: 15px 15px 15px -2px rgba(219, 219, 219, 1);

  }
</style>