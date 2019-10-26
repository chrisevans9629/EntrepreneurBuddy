import Vue from 'vue'
Vue.config.productionTip = false
Vue.component('mentor-list', require('./components/MentorList.vue').default);
Vue.component('mentor-card', require('./components/MentorCard.vue').default);
Vue.component('mentoring-requests', require('./components/MentoringRequests.vue').default);

window.Vue = Vue;

