<template>
  <div class="dashboard-container">
    <div class="grid-dashboard">
      <div class="header">
        <div class="title">{{ this.model.nazivKursa }}</div>
        <btn
          :styleBtn="'primary'"
          :title="'Nazad'"
          :icon="'solid-arrow-left'"
          style="margin-bottom: 0px !important"
          @click="goBack()"
        ></btn>
      </div>
      <div class="bulk" v-if="this.selected.length > 0">
        <btn
          :styleBtn="'secondary'"
          :title="'Sačuvaj studente u kurs'"
          :icon="'solid-save'"
          @click="saveStudents()"
        ></btn>
      </div>
      <table class="mytable">
        <thead>
          <tr>
            <th>
              <label class="checkbox-container">
                <input type="checkbox" id="checkbox" v-model="selectAll" />
                <span class="checkmark"></span>
              </label>
            </th>
            <th>Ime</th>
            <th>Prezime</th>
            <th>Broj Indeksa</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(tr, indextr) in students" v-bind:key="indextr">
            <td>
              <label class="checkbox-container">
                <input
                  type="checkbox"
                  id="checkbox"
                  v-model="selected"
                  :value="tr.pkStudentID"
                />
                <span class="checkmark"></span>
              </label>
            </td>
            <td>{{ tr.ime }}</td>
            <td>{{ tr.prezime }}</td>
            <td class="bold">{{ tr.brojIndeksa }}</td>
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
      model: [],
      students: [],
      selected: [],
      message: ""
    };
  },
  methods: {
    redirectToComponent(component) {
      if (this.$route.name == component) return;
      this.$router.push({ name: component });
    },
    goBack() {
      this.$router.go(-1);
    },
    getById() {
      store
        .dispatch("GET_DETAILS_COURSE", this.$route.params.pkCourseId)
        .then((response) => {
          this.model = response.data.course;
        })
        .catch((error) => {
          this.$toastr.error(error, "Greška");
        });
    },
    getStudents() {
      store
        .dispatch("GET_STUDENTS_NOT_IN_COURSE", this.$route.params.pkCourseId)
        .then((response) => {
          this.students = response.data.students;
        })
        .catch((error) => {
          this.$toastr.error(error, "Greška");
        });
    },
    saveStudents() {
      var $this = this;
      var list = [];
      $this.selected.forEach((element) => {
        list.push({
          pkCourseId: Number.parseInt($this.$route.params.pkCourseId, 10),
          pkStudentID: element
        });
      });
      store
        .dispatch("SAVE_STUDENTS_COURSE", list)
        .then((response) => {
          $this.selected = [];
          $this.$toastr.success(
            "Studenti su uspješno dodati u kurs!",
            "Uspješno"
          );
          $this.getStudents();
        })
        .catch((error) => {
          this.message = error.data.message;
          $this.$toastr.error(this.message, "Greška");
        });
    }
  },
  created() {
    this.getById();
    this.getStudents();
  },
  computed: {
    selectAll: {
      get: function () {
        return this.students
          ? this.selected.length == this.students.length
          : false;
      },
      set: function (value) {
        var selected = [];

        if (value) {
          this.students.forEach(function (student) {
            selected.push(student.pkStudentID);
          });
        }
        this.selected = selected;
      }
    }
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
    margin-bottom: 30px;
    border-radius: 4px;
    box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.05);
    background: #fff;
    padding: 20px 40px;
    .title {
      font-size: 36px;
      text-align: left;

      span {
        font-size: 24px;
        display: block;
      }
    }
  }
  .bulk {
    text-align: left;
  }
}
table.mytable {
  font-family: "Roboto";
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
      &:hover {
        background: #fbfbfb;
      }
    }
  }
}
</style>
