<template>
  <div class="sidebar-container">
    <div class="logo">
      <img
        :src="require(`../../assets/img/logo.png`)"
        class="logo-img"
        alt="logo"
      />
    </div>
    <ul class="menu">
      <li class="menu-item">
        <span> <i class="icon-solid-chart-line icon"></i></span>
        <span>Dashboard</span>
      </li>
      <li class="menu-item">
        <span> <i class="icon-solid-layer-group icon"></i></span>
        <span>Kursevi</span>
      </li>
      <li class="menu-item">
        <span><i class="icon-solid-graduation-cap icon"></i></span>
        <span>Studenti</span>
      </li>
      <li class="menu-item">
        <span><i class="icon-solid-bars icon"></i></span> <span>Godina</span>
      </li>
    </ul>
    <div class="footer">
      <div class="footer-title">Course Managment System</div>
      <div class="footer-year">2021</div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    menu: {
      type: Object,
      default: null
    }
  }
};
</script>

<style lang="scss" scoped>
.sidebar-container {
  position: fixed;
  width: 256px;
  top: 0px;
  left: 0px;
  display: flex;
  flex-direction: column;
  align-items: center;
  background: #ffffff;
  height: 100%;
  min-height: 100vh;
  box-shadow: 1px 0px 4px #f0f0f0;
  z-index: 99;
  overflow-y: auto;
  overflow-x: hidden;
  scrollbar-color: #62b2fd transparent !important;
  scrollbar-width: thin !important;
  &::-webkit-scrollbar {
    width: 7px;
  }

  &::-webkit-scrollbar-track {
    background: transparent;
  }

  &::-webkit-scrollbar-thumb {
    background: #188fff79;
    border-radius: 10px;
  }

  &::-webkit-scrollbar-thumb:hover {
    background: #62b2fd;
  }
  .logo {
    margin-top: 33px;
    text-align: left;
    margin-bottom: 52px;
    img.logo-img {
      width: 200px;
      text-align: center;
    }
  }
  .menu {
    width: 100%;
    .menu-item {
      font-family: "Roboto", sans-serif;
      font-style: normal;
      font-weight: normal;
      color: rgba(0, 0, 0, 0.85);
      color: rgba(0, 0, 0, 0.85);
      column-gap: 20px;
      list-style: none;
      height: 40px;
      line-height: 40px;
      text-align: left;
      padding-left: 24px;
      i {
        color: #1890ff;
        margin-right: 15px;
        font-size: 15px;
      }
      a {
        display: flex;
        align-items: center;
        font-family: "Roboto", sans-serif;
        font-style: normal;
        font-weight: normal;
        font-size: 14px !important;
        line-height: 22px !important;
        color: rgba(0, 0, 0, 0.85);
      }
    }
  }

  .footer {
    margin-top: auto;
    margin-bottom: 30px;
    &-title {
      font-size: 18px;
      line-height: 21px;
    }
    &-year {
      font-size: 12px;
      line-height: 14px;
    }
  }
}
</style>
