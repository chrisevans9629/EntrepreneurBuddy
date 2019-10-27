<style scoped>
    .mentor-request-card {
        background-color: #F5F4F4;
    }

    .card-img {
        position: relative;
        align-self: auto;
        width: 400px;
        height: 300px;
        background-position: 50% 50%;
        background-repeat: no-repeat;
        /* background-size: cover; */
        object-fit: cover;
    }
</style>

<template>

    <div>
        <div v-if="loading"><img src="/images/loader.gif" alt=""></div>
        <div v-else>
            <div class="container">
                <div class="row align-items-center">
                    <div class="col-md-4">
                        <img class="card-img img-fluid" :src="mentor.imageUrl">
                    </div>

                    <div class="col-md-8">
                        <div class="ml-2 mt-3">
                            <h3 class="name-color font-weight-bold">{{mentor.firstName}} {{mentor.lastName}} | {{mentor.position}}</h3>
                            <p>{{mentor.bio}}</p>
                            <div class="badge badge-pill text-white badge-blue mr-2 mb-4" v-for="skill in mentor.skillsList" :key="skill">{{skill}}</div>
                            <div class="d-flex">
                                <p>{{mentor.rating}}</p>
                                <img src="/images/thumbs-up-solid.png" class="thumb ml-2" />
                            </div>
                            <div class="d-flex" v-if="mentor.linkedInUrl != null">
                                <a :href="mentor.linkedInUrl"><img src="/images/li.png" class="ml-3" style="width:50px;height:50px" /></a>
                                <p>Connect with {{mentor.firstName}} on LinkedIn!</p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="card mt-5">
                    <div class="border">
                        <div class="navbar-custom tutor-request-card py-3">
                            <div class="pl-2 ">
                                <span class="h1 pl-2 text-white">Requests</span>
                                <a href="#" class="button-light mx-5 float-right" @click="launchCreateRequestModal()" v-if="ismentor=='False'">+ Add Request</a>
                            </div>
                        </div>
                    </div>
                    <div class="row mx-0">
                        <div v-for="request in mentoringRequests" class="col-md-4 p-4 " :key="request.id">
                            <request-card :request="request" :ismentor="ismentor" :getMentoringRequests="getMentoringRequests" :currentMentor="currentMentor"></request-card>
                        </div>
                    </div>
                </div>


            </div>
        </div>

        <modal name="request-modal" height="auto" :scrollable="true">
            <div class="px-5 py-3">
                <div class="row">
                    <div class="col-12">
                        <h4>Add Request</h4>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-12">
                        <input class="form-control" placeholder="Request Topic" v-model="requestForm.topic">
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-2 offset-8">
                        <button type="button" class="button" @click="$modal.hide('request-modal')">Cancel</button>
                    </div>
                    <div class="col-2">
                        <button type="button" class="button" @click="submitRequest">
                            Submit
                        </button>
                    </div>
                </div>
            </div>
        </modal>
    </div>

</template>

<script>
    import axios from 'axios';

    export default {
        name: 'MentoringRequests',
        data: () => ({
            mentoringRequests: [],
            loading: false,
            currentUser: null,
            currentMentor: null,
            requestForm: {
                topic: '',
                mentorId: 0
            }
        }),
        props: {
            mentor: {
                type: Object,
                default: () => { }
            },
            ismentor: {
                type: String,
                default: 'False'
            }
        },

        mounted() {
            this.getMentoringRequests();
            this.getUser();
            this.getMentors();
        },

        methods: {
            async getMentoringRequests() {
                this.loading = true;
                const { data } = await axios.get('/api/MentoringRequests/' + this.mentor.id);
                this.mentoringRequests = data;
                this.loading = false;
            },

            async getUser() {
                const { data } = await axios.get('/api/Entrepenuers/Current/');
                this.currentUser = data;
            },
            async getMentors() {
                const { data } = await axios.get('/api/Mentors/Current/');
                this.currentMentor = data;
            },

            async launchCreateRequestModal() {
                this.requestForm.topic = '';
                this.$modal.show('request-modal');
            },

            async submitRequest() {
                this.requestForm.mentorId = this.mentor.id;
                this.loading = true;
                await axios.post('/api/mentoringrequests/', this.requestForm);
                this.$modal.hide('request-modal');
                await this.getMentoringRequests();
            }


        },
    };
</script>