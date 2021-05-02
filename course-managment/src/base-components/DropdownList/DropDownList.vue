<template>
  <div class="dropdown-list" :tabindex="tabindex" @blur="open = false">
    <span class="span-arrow">
      <img
        class="icon rotate"
        src="./icons/chevron-down.svg"
        alt=""
        :class="{ down: open }"
        @click="open = !open"
      />
    </span>

    <div @click="open = !open" class="selected" :class="errorClass">
      {{ selected.name }}
    </div>
    <div class="items" :class="[{ selectHide: !open }]">
      <div
        v-for="(option, i) of options"
        :key="i"
        @click="clickItem(option)"
        class="emit-out-side"
      >
        {{ option.name }}
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    type: {
      type: String,
      default: ""
    },
    options: {
      type: Array,
      required: true
    },
    default: {
      type: Object,
      required: false,
      default: null
    },
    tabindex: {
      type: Number,
      required: false,
      default: 0
    },
    errorClass: {
      type: String,
      default: ""
    }
  },
  data() {
    return {
      selected: this.default
        ? this.default
        : this.options.length > 0
        ? this.options[0]
        : null,
      open: false
    };
  },
  methods: {
    clickItem(option) {
      this.selected = option;
      this.open = false;
      this.$emit("input", option.id);
    }
  },
  mounted() {
    this.$emit("input", this.selected.id);
  },
  watch: {
    default: function (newValue) {
      this.selected = this.default;
    }
  }
};
</script>

<style scoped lang="scss">
.dropdown-list {
  position: relative;
  width: 100%;
  text-align: left;
  font-family: "Sarabun", sans-serif;
  font-style: normal;
  font-weight: normal;
  font-size: 16px;
  outline: none;
  height: 48px;
  line-height: 48px;
  height: auto;
  padding: 0;
  border: none;
  .span-arrow {
    position: absolute;
    top: 3px;
    right: 20px;

    img {
      cursor: pointer;
      width: 16px;
      height: 10px;
    }
    .rotate {
      -moz-transition: all 0.5s linear;
      -webkit-transition: all 0.5s linear;
      transition: all 0.5s linear;
    }
    .rotate.down {
      -ms-transform: rotate(180deg);
      -moz-transform: rotate(180deg);
      -webkit-transform: rotate(180deg);
      transform: rotate(180deg);
    }
  }
  .selected {
    height: 55px;
    background: #f8f8f8;
    padding: 17px;
    outline: none;
    font-family: "Roboto";
    font-style: normal;
    font-weight: normal;
    font-size: 16px;
    line-height: 21px;
    letter-spacing: 0.02em;
    padding-right: 40px;
    color: #6b6b6b;
    border-radius: 4px;
  }

  .items {
    color: #fff;
    overflow: hidden;
    position: absolute;
    background-color: #fff;
    // height: 48px;
    line-height: 48px;
    left: 0;
    right: 0;
    z-index: 1;
    height: auto;
    min-height: 48px;
    max-height: 288px;
    overflow-y: auto;
    box-shadow: 0px 2px 8px rgba(0, 0, 0, 0.15);
    scrollbar-color: #6b6b6b7c #f3f3f391 !important;
    scrollbar-width: thin !important;
  }
  .items::-webkit-scrollbar {
    width: 10px;
  }

  .items::-webkit-scrollbar-track {
    background: #f3f3f391;
  }

  .items::-webkit-scrollbar-thumb {
    background: #6b6b6b7c;
    border-radius: 10px;
  }

  .items::-webkit-scrollbar-thumb:hover {
    background: #57575785;
  }

  .items div {
    color: #6b6b6b;
    padding-left: 1em;
    cursor: pointer;
    user-select: none;
    padding-left: 1.56em;
    overflow: hidden;
    white-space: nowrap;
    text-overflow: ellipsis;
    padding-right: 1em;
  }
  .items div:hover {
    background-color: #1890ff;
    color: #fff;
  }
  .selectHide {
    display: none;
  }
}
</style>
