<template>
  <div v-if="loading"><img src="/images/loader.gif" alt=""></div>
  <div v-else class="container">
    <div class="row">
      <div v-for="mentor in mentors" :key="mentor.id" class="col-md-4">
        <mentor-card rounded :mentor="mentor"></mentor-card>
      </div>
    </div>
  </div>
</template>
<script>
  import axios from 'axios';

  export default {
    name: 'MentorList',

    data: () => ({
      mentors: [],
      loading: false,

    }),

    mounted() {
      this.getMentors();
    },

    methods: {
      async getMentors() {
        this.loading = true;
        const { data } = await axios.get('/api/Mentors');
        this.mentors = data;
        this.loading = false;

      },

    },
  };
</script>