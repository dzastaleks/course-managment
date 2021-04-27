<template>
  <div id="app">
    <router-view />
  </div>
</template>
<script>
import store from "./store/index";
import { mapState } from "vuex";
export default {
  created() {
    // document.title = this.lang("general.app_title");
    var token = localStorage.getItem("token");
    if (token != null) {
      store.commit("SET_TOKEN", token);
      store.commit(
        "SET_USER",
        JSON.stringify(JSON.parse(localStorage.getItem("user")))
      );
      // hub(store, notificationToken);
    }
  }
};
</script>

<style lang="scss">
@import "./assets/main";
@import "./assets/icons/style.css";
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
