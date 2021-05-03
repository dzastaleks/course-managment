<template>
  <div class="error-container">
    <div class="error">
      <div class="status">
        <div class="logo">
          <img
            class="logo-img"
            :src="require(`../assets/img/logo.png`)"
            alt=""
          />
        </div>
        <div class="status-code">
          {{ "404" }}
        </div>
      </div>
      <div class="btn-div">
        <btn :styleBtn="'primary'" @click="goHome()" :title="'Početna'"></btn>
      </div>
    </div>
  </div>
</template>
<script>
export default {
  methods: {
    goHome() {
      this.$router.push({ name: "DashboardIndex" });
    }
  }
};
</script>
<style lang="scss" scoped>
.error-container {
  width: 100%;
  height: 100vh;
  overflow: hidden;
  position: relative;
  .error {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    text-align: center;
    .logo {
      img.logo-img {
        width: 200px;
        text-align: center;
        margin-bottom: 20px;
      }
    }
    .status-code {
      font-family: "Roboto", sans-serif;
      font-size: 120px;
      margin-bottom: 30px;
    }
  }
}
</style>
