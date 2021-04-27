import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import dashboardRouter from "@/views/dashboard/router";
import loginRouter from "@/views/login/router";
import store from "../store/index";

Vue.use(VueRouter);

const routes = [
  {
    path: "/home",
    name: "Home",
    component: Home,
  },
  {
    path: "/about",
    name: "About",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () =>
      import(/* webpackChunkName: "about" */ "../views/About.vue"),
  },
  ...dashboardRouter,
  ...loginRouter
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

router.beforeEach((to, from, next) => {
  var user = JSON.parse(localStorage.getItem("user"));

  //invalid token or user
  if ((localStorage.getItem("token") == null || user == null) && to.name != "Login") {
    return next({ name: "Login" });
  } 

  else if (to.path == "/" && localStorage.getItem("token") != null && user != null) {
    return next({ name: "DashboardIndex" });
  }
  //logout
  else if (to.path == "/logout") {
    localStorage.removeItem("token");
    localStorage.removeItem("user");
    store.state.user = null;
    store.state.token = null;
    return next({ name: "Login" });
  }
  //not found path
  else if (!to.matched.length) {
    next('/error/404');
  }

  next();
});
export default router;
