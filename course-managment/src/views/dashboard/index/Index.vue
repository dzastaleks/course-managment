<template>
  <div class="dashboard-container">
    <div class="grid-dashboar">
      <DashboardItem
        :title="'Kursevi'"
        :value="this.coursesCount"
        @click="redirectToComponent('Course')"
      />

      <DashboardItem
        :title="'Studenti'"
        :value="this.studentsCount"
        @click="redirectToComponent('Student')"
      />
      <DashboardItem
        :title="'Godine'"
        :value="this.yearsCount"
        @click="redirectToComponent('Year')"
      />
    </div>
  </div>
</template>

<script>
import store from "@/store/index";

import DashboardItem from "@/components/DashboardItem";
export default {
  components: { DashboardItem },
  data() {
    return {
      studentsCount: 0,
      coursesCount: 0,
      yearsCount: 0
    };
  },
  methods: {
    redirectToComponent(component) {
      if (this.$route.name == component) return;
      this.$router.push({ name: component });
    },
    getAll() {
      store
        .dispatch("GET_DATA_DASH")
        .then((response) => {
          this.coursesCount = response.data.coursesCount;
          this.studentsCount = response.data.studentsCount;
          this.yearsCount = response.data.yearsCount;
        })
        .catch((error) => {
          console.log(error);
        });
    }
  },
  created() {
    this.getAll();
  }
};
</script>
<style lang="scss" scoped>
.dashboard-container {
  padding: 40px 70px 50px 300px;
  overflow-x: auto;
  // min-width: 1120px;
}
.grid-dashboar {
  display: grid;
  grid-column-gap: 30px;
  grid-row-gap: 50px;
  grid-template-columns: 1fr 1fr 1fr;
}
</style>
