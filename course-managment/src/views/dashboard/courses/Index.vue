<template>
  <div class="dashboard-container">
    <div class="grid-dashboard">
      <div class="header">
        <div class="title">Kursevi</div>
        <btn
          :styleBtn="'primary'"
          :title="'Dodaj novi kurs'"
          :icon="'solid-plus'"
          @click="redirectToComponent('CourseCreate')"
        ></btn>
      </div>
      <table class="mytable">
        <thead>
          <tr>
            <th>ID</th>
            <th>Naziv Kursa</th>
            <th>Broj Studenata</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(tr, indextr) in courses" v-bind:key="indextr">
            <td>{{ tr.pkCourseId }}</td>
            <td class="bold">{{ tr.nazivKursa }}</td>
            <td class="bold">{{ tr.nazivKursa }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import store from "@/store/index";

export default {
  components: {},
  data() {
    return {
      courses: []
    };
  },
  methods: {
    redirectToComponent(component) {
      if (this.$route.name == component) return;
      this.$router.push({ name: component });
    },
    getAll() {
      store
        .dispatch("course/GET_ALL")
        .then((response) => {
          this.courses = response.data.courses;
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
.grid-dashboard {
  // display: grid;
  // grid-column-gap: 30px;
  // grid-row-gap: 50px;
  // grid-template-columns: 1fr 1fr 1fr;
  .header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    .title {
      font-size: 36px;
      text-align: left;
      margin-bottom: 30px;
    }
  }
}
table.mytable {
  font-family: "Sarabun";
  font-style: normal;
  font-weight: normal;
  font-size: 14px;
  line-height: 22px;
  width: 100%;
  border-collapse: collapse;
  background: #fff;
  border-radius: 4px;
  thead {
    tr {
      height: 56px;
      font-size: 14px;
      line-height: 22px;
      border-bottom: 1px solid #f0f0f0;
      th {
        font-family: "Sarabun", sans-serif;
        font-style: normal;
        font-weight: normal;
        font-size: 14px;
        line-height: 22px;
        color: rgba(0, 0, 0, 0.85);
        text-align: left;
        padding-left: 16px;
        border-bottom: 1px solid #f0f0f0;
      }
    }
  }
  tbody {
    tr {
      height: 56px;
      font-size: 14px;
      line-height: 22px;
      td {
        font-family: "Sarabun", sans-serif;
        font-style: normal;
        font-weight: normal;
        font-size: 14px;
        line-height: 22px;
        color: rgba(0, 0, 0, 0.65);
        text-align: left;
        padding-left: 16px;
        border-bottom: 1px solid #f0f0f0;
      }
      td.bold {
        font-family: "Sarabun", sans-serif;
        font-style: normal;
        font-weight: bold;
        font-size: 14px;
        line-height: 22px;
        color: rgba(0, 0, 0, 0.65);
        text-align: left;
        padding-left: 16px;
      }
      &:hover {
        background: #fbfbfb;
      }
    }
  }
}
</style>
