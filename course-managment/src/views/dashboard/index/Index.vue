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
      <DashboardItem
        :title="'Novo'"
        v-for="course in this.newCourses"
        :key="course.pkCourseId"
        @click="detailsClick(course.pkCourseId)"
      >
        <div slot="content">{{ course.nazivKursa }}</div>
      </DashboardItem>
      <DashboardItem
        :title="'Dodaj Novi Kurs'"
        @click="redirectToComponent('CourseCreate')"
        ><div slot="content">
          <i class="icon-solid-layer-plus"></i></div
      ></DashboardItem>
      <DashboardItem
        :title="'Dodaj Novog Studenta'"
        @click="redirectToComponent('StudentCreate')"
        ><div slot="content"><i class="icon-solid-user-plus"></i></div
      ></DashboardItem>
      <DashboardItem
        :title="'Dodaj Novu Godinu'"
        @click="redirectToComponent('YearCreate')"
        ><div slot="content"><i class="icon-solid-folder-plus"></i></div
      ></DashboardItem>
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
      yearsCount: 0,
      newCourses: []
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
          this.newCourses = response.data.newCourses;
          console.log(response.data);
        })
        .catch((error) => {
          console.log(error);
        });
    },
    detailsClick(id) {
      this.$router.push({
        name: "CourseDetails",
        params: { pkCourseId: id }
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
  grid-row-gap: 70px;
  grid-template-columns: 1fr 1fr 1fr;
  &-full {
    margin-top: 50px;
    grid-template-columns: 1fr;
  }
}
</style>
