<template>
  <div class="dashboard-container">
    <div class="grid-dashboard">
      <div class="header">
        <div class="title">Kursevi</div>
        <btn
          :styleBtn="'primary'"
          :title="'Dodaj novi kurs'"
          :icon="'regular-plus'"
          style="margin-bottom: 0px"
          @click="redirectToComponent('CourseCreate')"
        ></btn>
      </div>
      <table class="mytable">
        <thead>
          <tr>
            <th>ID</th>
            <th>Naziv Kursa</th>
            <th>Broj Studenata</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="(tr, indextr) in courses"
            v-bind:key="indextr"
            @mouseover="showActionButtons(indextr)"
          >
            <td>{{ tr.pkCourseId }}</td>
            <td class="bold click" @click="detailsClick(tr.pkCourseId)">
              {{ tr.nazivKursa }}
            </td>
            <td class="bold">
              {{ tr.studentsCount }}
            </td>
            <td>
              <div class="actions" v-show="buttonsIndex === indextr">
                <btn
                  :styleBtn="'primary'"
                  :title="''"
                  :icon="'solid-eye'"
                  style="margin-right: 10px"
                  @click="detailsClick(tr.pkCourseId)"
                ></btn>
                <btn
                  :styleBtn="'secondary'"
                  :title="''"
                  :icon="'solid-pen'"
                  style="margin-right: 10px"
                  @click="editClick(tr.pkCourseId)"
                ></btn>
                <btn
                  :styleBtn="'danger'"
                  :title="''"
                  :icon="'solid-trash'"
                  @click="deleteClick(tr.pkCourseId)"
                ></btn>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import store from "@/store/index";
import $ from "jquery";

export default {
  components: {},
  data() {
    return {
      courses: [],
      buttonsIndex: 0
    };
  },
  methods: {
    redirectToComponent(component) {
      if (this.$route.name == component) return;
      this.$router.push({ name: component });
    },
    getAll() {
      store
        .dispatch("GET_ALL_COURSE")
        .then((response) => {
          this.courses = response.data.courses;
        })
        .catch((error) => {
          this.message = error;
          this.$toastr.error(this.message, "Greška");
        });
    },
    detailsClick(id) {
      this.$router.push({
        name: "CourseDetails",
        params: { pkCourseId: id }
      });
    },
    editClick(id) {
      this.$router.push({
        name: "CourseEdit",
        params: { pkCourseId: id }
      });
    },
    deleteClick(id) {
      var $this = this;
      $this.$toastr.info(
        "<br /><br /><button type='button' id='confirmationRevertYes' class='warn-btn'>Potvrdi</button>",
        "Da li ste sigurni da želite da obrišete ovaj kurs?",
        {
          closeButton: false,
          allowHtml: true,
          onShown: function (toast) {
            $("#confirmationRevertYes").click(function () {
              store
                .dispatch("DELETE_COURSE", id)
                .then((response) => {
                  $this.$toastr.success("Kurs je obrisan!", "Uspješno");
                  $this.getAll();
                })
                .catch((error) => {
                  $this.$toastr.error(error, "Greška");
                });
            });
          }
        }
      );
    },
    showActionButtons(id) {
      this.buttonsIndex = id;
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
  font-family: "Roboto", sans-serif;
  .header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    background: #fff;
    padding: 20px 40px;
    border-radius: 4px;
    box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.05);
    margin-bottom: 30px;

    .title {
      font-size: 36px;
      text-align: left;
    }
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
      td.click {
        font-family: "Roboto", sans-serif;
        font-style: normal;
        font-weight: bold;
        cursor: pointer;
      }
      td.click:hover {
        text-decoration: underline;
      }
      td:last-child {
        text-align: right !important;
        padding-right: 10px;
        padding-top: 10px;
      }
      &:hover {
        background: #fbfbfb;
      }
    }
  }
}
</style>
