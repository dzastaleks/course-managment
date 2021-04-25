import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";




import baseButton from "@/base-components/Buttons/Button";
import sidebar from "@/base-components/Sidebar/Sidebar";



Vue.component("btn", baseButton);
Vue.component("sidebar", sidebar);

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
