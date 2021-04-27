import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";
import modules from "../vuex/index"

Vue.use(Vuex);
const $api ="https://localhost:44328/";

export default new Vuex.Store({
  state: {
    token:null,
    $axios: axios.create({
      baseURL: $api
    }),
    $axios_auth: axios.create({
      baseURL: $api
    }),
    user:null
  },
  mutations: {
    SET_TOKEN: function (state, token) {
      localStorage.setItem("token", token);
      state.token = token;
      if (state.$axios_auth) {
        state.$axios_auth.defaults.headers.common.Authorization = token;
      }
    },
    SET_USER: function (state, user) {
      localStorage.setItem("user", user);
      state.user = JSON.parse(user);
    },
    LOGOUT_USER: function (state) {
      localStorage.removeItem("user");
      localStorage.removeItem("token");
      state.token = null;
      state.user = null;
      state.$axios = axios.create({
        baseURL: $api
      })
    },
    SHOW_LOADER: function (state) {
      state.showLoader = true;
    },
    HIDE_LOADER: function (state) {
      state.showLoader = false;
    },
  },
  actions: {},
  modules: modules,
});
