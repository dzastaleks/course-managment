import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import VeeValidate, { Field } from 'vee-validate';
import {Validator} from 'vee-validate';
import VueToastr2 from 'vue-toastr-2'
import 'vue-toastr-2/dist/vue-toastr-2.min.css'



window.toastr = require('toastr')


import baseButton from "@/base-components/Buttons/Button";
import sidebar from "@/base-components/Sidebar/Sidebar";
import dropdown from "@/base-components/DropdownList/DropDownList";


Vue.use(VueToastr2);
Vue.use(VeeValidate);

Vue.component("btn", baseButton);
Vue.component("sidebar", sidebar);
Vue.component("dropdown",dropdown);

Vue.config.productionTip = false;

Validator.extend("dropdown-required", {
  getMessage:()=>{
    return "Polje je obavezno!";
  },
  validate: (value)=>{
   if((value!==0)){
     return true;
   }else{
     return false;
   }
  }
});

new Vue({
  router,
  store,
  VeeValidate,
  render: (h) => h(App),
  created: function(){
    var $this = this;
    store.state.$axios_auth.interceptors.response.use(
      function (response) {
        return response;
      },
      function (error) {
        setTimeout(() => {
          if (error.response && error.response.status == 401) {
            localStorage.removeItem("token");
            localStorage.removeItem("user");
            store.state.user = null;
            store.state.token = null;
            $this.$router.push({name:"Login"});
          } else if (error.response && error.response.status == 403) {
            $this.$router.push({
              name: "ErrorPage",
              params: { statusCode: "403" }
            });
          } else if (error.response && error.response.status == 404) {
            $this.$router.push({
              name: "ErrorPage",
              params: { statusCode: "404" }
            });
          } else if (error.response && error.response.status == 500) {
            // show("Warning","An error occurred. Contact your system administrator.","warning");
          }
        }, 500);
        return Promise.reject(error);
      }
    );
  }
}).$mount("#app");
