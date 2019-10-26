<style scoped>
  .search-icon {
    height: 20px;
  }


  has-search .form-control-feedback {
    position: absolute;
    z-index: 2;
    display: block;
    width: 2.375rem;
    height: 2.375rem;
    line-height: 2.375rem;
    text-align: center;
    pointer-events: none;
    color: #aaa;
  }
</style>

<template>
  <div v-if="loading"><img src="/images/loader.gif" alt=""></div>

  <div v-else class="container">
    <div class="d-flex justify-content-between align-items-center">
      <h1 class="display-4 name-color mb-4 font-weight-bold text-center">Mentors</h1>

      <div class="form-group has-search">
        <img class="search-icon" src="/images/search-icon.png">
        <input v-model="filter" placeholder="Search"></input>
      </div>

    </div>
    <div class="row">
      <div v-for="mentor in filteredMentors" :key="mentor.id" class="col-md-4">
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
      filter: '',

    }),

    mounted() {
      this.getMentors();
    },

    computed: {
      filteredMentors() {
        if (this.mentors.length === 0) {
          return []
        }
        let filtered = JSON.parse(JSON.stringify(this.mentors))
        filtered = filtered.filter(mentor =>
          mentor.firstName.toLowerCase().includes(this.filter.toLowerCase()) ||
          mentor.lastName.toLowerCase().includes(this.filter.toLowerCase()) ||
          mentor.position.toLowerCase().includes(this.filter.toLowerCase()) ||
          mentor.skills.toLowerCase().includes(this.filter.toLowerCase()) ||
          mentor.bio.toLowerCase().includes(this.filter.toLowerCase()))

        return filtered
      }
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