<template>
  <div class="dashboard-container">
    <div class="grid-dashboard">
      <div class="header">
        <div class="title">
          {{ this.model.ime }} {{ this.model.prezime }}
          <span>{{ this.model.brojIndeksa }}</span>
        </div>
        <btn
          :styleBtn="'primary'"
          :title="'Nazad'"
          :icon="'solid-arrow-left'"
          style="margin-bottom: 0px !important"
          @click="redirectToComponent('Student')"
        ></btn>
      </div>
      <div class="user-details">
        <div class="user-details-item" v-if="this.model.ime">
          <span>Ime</span>{{ this.model.ime }}
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
            <td
              class="bold click"
              @click="
                redirectToComponentWithParam('CourseDetails', tr.pkCourseId)
              "
            >
              {{ tr.nazivKursa }}
            </td>
          </tr>
        </tbody>
      </table>
      <div class="notify" v-else>Student nije registrovan na kurs!</div>
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
    redirectToComponentWithParam(component, id) {
      if (this.$route.name == component) return;
      this.$router.push({
        name: component,
        params: {
          pkCourseId: id
        }
      });
    },
    getById() {
      store
        .dispatch("GET_DETAILS_STUDENT", this.$route.params.pkStudentID)
        .then((response) => {
          this.model = response.data.student;
        })
        .catch((error) => {
          this.$toastr.error(error, "Greška");
        });
    },
    getCourses() {
      store
        .dispatch("GET_COURSES_STUDENT", this.$route.params.pkStudentID)
        .then((response) => {
          this.kursevi = response.data.kursevi;
        })
        .catch((error) => {
          this.$toastr.error(error, "Greška");
        });
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
  font-family: "Roboto", sans-serif;
  .header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 30px;
    border-radius: 4px;
    box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.05);
    background: #fff;
    padding: 20px 40px;
    .title {
      font-size: 36px;
      text-align: left;
      font-family: "Roboto", sans-serif;

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
    box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.05);

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
  font-family: "Roboto", sans-serif;
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
        font-family: "Roboto", sans-serif;
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
        font-family: "Roboto", sans-serif;
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
        font-family: "Roboto", sans-serif;
        font-style: normal;
        font-weight: bold;
        font-size: 14px;
        line-height: 22px;
        color: rgba(0, 0, 0, 0.65);
        text-align: left;
        padding-left: 16px;
      }
      td.click {
        font-family: "Roboto", sans-serif;
        font-style: normal;
        font-weight: bold;
        cursor: pointer;
      }
      td.click:hover {
        text-decoration: underline;
      }
      &:hover {
        background: #fbfbfb;
      }
    }
  }
}
.notify {
  background: #fff;
  box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.05);
  font-size: 32px;
  padding: 20px 40px;
}
</style>
