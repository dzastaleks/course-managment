<template>
  <button
    class="button-container"
    :class="[styleBtn]"
    v-on:click="click()"
    :type="type"
  >
    <span
      class="button-icon"
      :class="title == '' ? 'margin-right' : ''"
      v-if="icon != ''"
    >
      <i
        :class="['icon-' + icon, title == '' ? 'margin-right' : '']"
        class="icons"
        :style="'font-size:' + fontSize + 'px!important;'"
      ></i>
    </span>
    <span>{{ title }}</span>
  </button>
</template>

<script>
export default {
  props: {
    title: {
      type: String,
      default: ""
    },
    icon: {
      type: String,
      default: ""
    },
    disabled: {
      type: Boolean,
      default: false
    },
    styleBtn: {
      type: String,
      default: "prim"
    },
    type: {
      type: String,
      default: "submit"
    },
    fontSize: {
      type: Number,
      default: 12
    },
    enabledHover: {
      type: Boolean,
      default: false
    },
    hoverColor: {
      type: String,
      default: "#3690AC"
    }
  },
  data() {
    return {
      hover: false
    };
  },
  created() {
    if (this.title == "" && this.icon == "") this.title = "Add new item";
  },
  methods: {
    click() {
      this.$emit("click");
    },
    mouseover() {}
  }
};
</script>

<style lang="scss" scoped>
:root {
  --hover-color: "";
}
.button-container {
  line-height: 1.5715;
  position: relative;
  display: inline-block;
  font-weight: 400;
  white-space: nowrap;
  text-align: center;
  background-image: none;
  box-shadow: 0 2px 0 rgb(0 0 0 / 2%);
  cursor: pointer;
  transition: all 0.3s cubic-bezier(0.645, 0.045, 0.355, 1);
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
  touch-action: manipulation;
  height: 32px;
  padding: 4px 15px;
  font-size: 14px;
  border-radius: 2px;
  color: rgba(0, 0, 0, 0.85);
  background: #fff;
  border: 1px solid #d9d9d9;
  margin-bottom: 12px;
  .button-icon .icons {
    font-style: normal;
    line-height: 12px;
    letter-spacing: 0.02em;
    text-align: left;
    font-size: 12px;
    margin-right: 6px;
  }
}
.primary {
  color: #fff;
  background: #1890ff;
  border-color: #1890ff;
  text-shadow: 0 -1px 0 rgb(0 0 0 / 12%);
  box-shadow: 0 2px 0 rgb(0 0 0 / 5%);
}
.secondary {
  color: #fff;
  background: #fd7e14;
  border-color: #fd7e14;
  text-shadow: 0 -1px 0 rgb(0 0 0 / 12%);
  box-shadow: 0 2px 0 rgb(0 0 0 / 5%);
}
.danger {
  color: #fff;
  background: #eb1c24;
  border-color: #eb1c24;
  text-shadow: 0 -1px 0 rgb(0 0 0 / 12%);
  box-shadow: 0 2px 0 rgb(0 0 0 / 5%);
}
.margin-right {
  margin-right: 0px !important;
}
.min-width {
  min-width: 52px !important;
}
button.hover {
  color: var(--hover-color) !important;
}
</style>
