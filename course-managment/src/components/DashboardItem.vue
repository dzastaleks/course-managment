<template>
  <div class="dashborad-item" @click="click()">
    <div class="title">{{ title }}</div>
    <div class="content">
      {{ value ? value : "" }}
      <slot name="content"></slot>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    title: {
      type: String,
      default: ""
    },
    value: {
      type: Number,
      default: 0
    }
  },
  methods: {
    click() {
      this.$emit("click");
    }
  }
};
</script>

<style lang="scss" scoped>
.dashborad-item {
  font-family: "Roboto", sans-serif;
  width: 100%;
  height: 100%;
  background: #fff;
  border-radius: 4px;
  padding: 25px;
  box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.05);
  cursor: pointer;
  .title {
    font-family: "Roboto", sans-serif;
    font-style: normal;
    font-weight: bold;
    font-size: 16px;
    line-height: 21px;
    color: #1890ff;
    margin-bottom: 20px;
    text-align: left;
  }
  .content {
    text-align: center;
    margin-left: auto;
    margin-right: auto;
    font-size: 42px;
    margin-bottom: 20px;
  }
}
</style>
