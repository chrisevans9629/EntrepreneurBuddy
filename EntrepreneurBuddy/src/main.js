import Vue from 'vue'
import VModal from 'vue-js-modal'

Vue.config.productionTip = false
Vue.component('mentor-list', require('./components/MentorList.vue').default);
Vue.component('mentor-card', require('./components/MentorCard.vue').default);
Vue.component('mentoring-requests', require('./components/MentoringRequests.vue').default);
Vue.component('request-card', require('./components/RequestCard.vue').default);
Vue.use(VModal);

window.Vue = Vue;

