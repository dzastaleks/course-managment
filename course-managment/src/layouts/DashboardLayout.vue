<template>
  <div>
    <sidebar />
    <main role="main" class="main pt1 pt-lr-15">
      <router-view></router-view>
    </main>
  </div>
</template>

<script>
import Sidebar from "../base-components/Sidebar/Sidebar.vue";
export default {
  components: { Sidebar }
};
</script>

<style lang="scss" scoped>
.main {
  overflow: auto !important;
  height: 100vh;
  padding: 34px 39px 13px 304px;
}
.pt1 {
  padding-top: 1rem;
}
.pt-lr-15 {
  padding-left: 1.5rem;
  padding-right: 1.5rem;
}
</style>
