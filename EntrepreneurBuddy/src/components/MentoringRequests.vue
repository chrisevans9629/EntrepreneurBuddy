<style scoped>
  .mentor-request-card {
    background-color: #F5F4F4;

  }

  img {
    width: 300px;
  }
</style>

<template>
  <div>
    <div v-if="loading"><img src="/images/loader.gif" alt=""></div>
    <img :src="mentor.imageUrl">
    <div class="ml-3 mt-3">
      <p>{{mentor.firstName}} {{mentor.lastName}}</p>
      <p>{{mentor.bio}}</p>
      <p>{{mentor.skills}}</p>
      <p>{{mentor.rating}}</p>
    </div>
    <div class="row mx-0">
      <div v-for="request in mentoringRequests" class="col-md-4 p-4 " :key="request.id">
        <request-card :request="request"></request-card>
      </div>
    </div>
  </div>

</template>

<script>
  import axios from 'axios';

  export default {
    name: 'MentoringRequests',
    data: () => ({
      mentoringRequests: [],
      loading: false,
    }),
    props: {
      mentor: {
        type: Object,
        default: () => { }
      },
    },

    mounted() {
      this.getMentoringRequests();

    },

    methods: {
      async getMentoringRequests() {
        this.loading = true;
        const { data } = await axios.get('/api/MentoringRequests/' + this.mentor.id);
        this.mentoringRequests = data;
        this.loading = false;
      },

    },
  };
</script>