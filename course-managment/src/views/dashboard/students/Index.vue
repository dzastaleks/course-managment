<template>
  <div class="dashboard-container">
    <div class="grid-dashboard">
      <div class="header">
        <div class="title">Studenti</div>
        <btn
          :styleBtn="'primary'"
          :title="'Dodaj novog studenta'"
          :icon="'solid-plus'"
          style="margin-bottom: 0px !important"
          @click="redirectToComponent('StudentCreate')"
        ></btn>
      </div>
      <table class="mytable">
        <thead>
          <tr>
            <th>ID</th>
            <th>Ime</th>
            <th>Prezime</th>
            <th>Broj Indeksa</th>
            <th>Status</th>
            <th>Godina</th>
            <th>Broj Kurseva</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          <tr
            v-for="(tr, indextr) in students"
            v-bind:key="indextr"
            @mouseover="showActionButtons(indextr)"
          >
            <td>{{ tr.pkStudentID }}</td>
            <td class="bold click" @click="detailsClick(tr.pkStudentID)">
              {{ tr.ime }}
            </td>
            <td>{{ tr.prezime }}</td>
            <td class="bold">{{ tr.brojIndeksa }}</td>
            <td>{{ tr.status.naziv }}</td>
            <td>{{ tr.year.naziv }}</td>
            <td>{{ tr.coursesCount }}</td>
            <td>
              <div class="actions" v-show="buttonsIndex === indextr">
                <btn
                  :styleBtn="'primary'"
                  :title="''"
                  :icon="'solid-eye'"
                  @click="detailsClick(tr.pkStudentID)"
                  style="margin-right: 10px"
                ></btn>
                <btn
                  :styleBtn="'secondary'"
                  :title="''"
                  :icon="'solid-pen'"
                  @click="editClick(tr.pkStudentID)"
                  style="margin-right: 10px"
                ></btn>
                <btn
                  :styleBtn="'danger'"
                  :title="''"
                  :icon="'solid-trash'"
                  @click="deleteClick(tr.pkStudentID)"
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
  methods: {
    redirectToComponent(component) {
      if (this.$route.name == component) return;
      this.$router.push({ name: component });
    },
    getAll() {
      store
        .dispatch("GET_ALL_STUDENT")
        .then((response) => {
          this.students = response.data.students;
        })
        .catch((error) => {
          this.$toastr.error(error, "Greška");
        });
    },
    detailsClick(id) {
      this.$router.push({
        name: "StudentDetails",
        params: { pkStudentID: id }
      });
    },
    editClick(id) {
      this.$router.push({
        name: "StudentEdit",
        params: { pkStudentID: id }
      });
    },
    deleteClick(id) {
      var $this = this;
      $this.$toastr.info(
        "<br /><br /><button type='button' id='confirmationRevertYes' class='warn-btn'>Potvrdi</button>",
        "Da li ste sigurni da želite da obrišete studenta?",
        {
          closeButton: false,
          allowHtml: true,
          onShown: function (toast) {
            $("#confirmationRevertYes").click(function () {
              store
                .dispatch("DELETE_STUDENT", id)
                .then((response) => {
                  $this.$toastr.success("Student je obrisan!", "Uspješno");
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
  data() {
    return {
      students: [],
      buttonsIndex: 0
    };
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
    margin-bottom: 30px;
    background: #fff;
    padding: 20px 40px;
    border-radius: 4px;
    box-shadow: 0px 4px 4px rgba(0, 0, 0, 0.05);
    .title {
      font-size: 36px;
      text-align: left;
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
