<template>
  <div class="dashboard-container">
    <div class="grid-dashboard">
      <div class="header">
        <div class="title">
          {{ this.model.ime }} {{ this.model.prezime }}
          <span>{{ this.model.brojIndeksa }}</span>
        </div>
        <!-- <btn
          :styleBtn="'primary'"
          :title="'Dodaj novi kurs'"
          :icon="'solid-plus'"
          @click="redirectToComponent('CourseCreate')"
        ></btn> -->
      </div>
      <div class="user-details">
        <div class="user-details-item" v-if="this.model.ime">
          <span>Ime</span> {{ this.model.ime }}
        </div>
        <div class="user-details-item" v-if="this.model.prezime">
          <span>Prezime</span>{{ this.model.prezime }}
        </div>
        <div class="user-details-item" v-if="this.model.brojIndeksa">
          <span>Broj Indeksa</span>{{ this.model.brojIndeksa }}
        </div>
        <div class="user-details-item" v-if="this.model.status">
          <span>Status</span>{{ this.model.status.naziv }}
        </div>
        <div class="user-details-item" v-if="this.model.year">
          <span>Godina</span>{{ this.model.year.naziv }}
        </div>
      </div>
      <table class="mytable" v-if="Object.keys(this.kursevi).length > 0">
        <thead>
          <tr>
            <th>ID</th>
            <th>Naziv Kursa</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(tr, indextr) in this.kursevi" v-bind:key="indextr">
            <td>{{ tr.pkCourseId }}</td>
            <td class="bold">{{ tr.nazivKursa }}</td>
          </tr>
        </tbody>
      </table>
      <div class="notify" v-else>Ovaj student nije registrovan na kurseve!</div>
    </div>
  </div>
</template>

<script>
import store from "@/store/index";

export default {
  components: {},
  data() {
    return {
      model: [],
      kursevi: []
    };
  },
  methods: {
    redirectToComponent(component) {
      if (this.$route.name == component) return;
      this.$router.push({ name: component });
    },
    getById() {
      store
        .dispatch("student/GET_DETAILS", this.$route.params.pkStudentID)
        .then((response) => {
          this.model = response.data.student;
        })
        .catch((error) => {});
    },
    getCourses() {
      store
        .dispatch("student/GET_COURSES", this.$route.params.pkStudentID)
        .then((response) => {
          this.kursevi = response.data.kursevi;
        })
        .catch((error) => {});
    }
  },
  created() {
    this.getById();
    this.getCourses();
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
      background: #fff;
      padding: 20px 40px;
      font-size: 36px;
      text-align: left;
      margin-bottom: 30px;
      border-radius: 4px;
      box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.05);
      span {
        font-size: 24px;
        display: block;
      }
    }
  }
  .user-details {
    background: #fff;
    padding: 40px;
    margin-bottom: 40px;
    text-align: left;
    display: table;
    &-item {
      margin-bottom: 10px;
      font-weight: bold;
      span {
        min-width: 140px;
        display: inline-block;
        margin-right: 10px;
        font-weight: normal;
      }
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
.notify {
  background: #fff;
  font-size: 32px;
  padding: 20px 40px;
}
</style>
