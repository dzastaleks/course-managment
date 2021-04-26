import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";
import modules from "../vuex/index"

Vue.use(Vuex);
const $api ="https://localhost:44328/";

export default new Vuex.Store({
  state: {
    $axios: axios.create({
      baseURL: $api
    }),
    $axios_auth: axios.create({
      baseURL: $api
    })
  },
  mutations: {},
  actions: {},
  modules: modules,
});
