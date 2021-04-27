<template>
  <div class="dashboard-container">
    <div class="grid-dashboard">
      <div class="title">Novi Student</div>
      <div class="form-card">
        <h1>Dodajte novog studenta</h1>
        <div class="form-items">
          <div class="input-group">
            <label for="ime">Ime: </label>
            <input
              type="text"
              placeholder="Unesite Ime studenta"
              v-model="model.ime"
            />
          </div>
          <div class="input-group">
            <label for="prezime">Prezime: </label>
            <input
              type="text"
              placeholder="Unesite Prezime studenta"
              v-model="model.prezime"
            />
          </div>
          <div class="input-group">
            <label for="brojIndeksa">Broj Indeksa: </label>
            <input
              type="text"
              placeholder="Unesite Broj indeksa studenta"
              v-model="model.brojIndeksa"
            />
          </div>
          <div class="input-group">
            <label for="Status">Status:</label>
            <dropdown
              :options="statusDropdownOptions"
              :default="statusDropdownDefault"
              @input="handleDropdownStatus"
              :tabindex="1"
            ></dropdown>
          </div>
          <div class="input-group">
            <label for="Godina">Godina:</label>
            <dropdown
              :options="godinaDropdownOptions"
              :default="godinaDropdownDefault"
              @input="handleDropdownYear"
              :tabindex="1"
            ></dropdown>
          </div>
          <div>
            <btn :styleBtn="'primary'" :title="'Sačuvaj'" @click="save()"></btn>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import store from "@/store/index";

export default {
  components: {},
  methods: {
    handleDropdownStatus(value) {
      this.model.statusId = value;
    },
    handleDropdownYear(value) {
      this.model.yearId = value;
    },
    save() {
      console.log(this.model);
      if (this.$route.params.pkStudentID == null) {
        store
          .dispatch("student/CREATE", this.model)
          .then((response) => {
            console.log(response);
          })
          .catch((error) => {
            console.log(error);
          });
      } else {
        store
          .dispatch("student/EDIT", this.model)
          .then((response) => {
            console.log(response);
          })
          .catch((error) => {
            console.log(error);
          });
      }
    },
    getAllYears() {
      store
        .dispatch("year/GET_ALL")
        .then((response) => {
          this.godinaDropdownOptions = [];
          response.data.years.forEach((element) => {
            this.godinaDropdownOptions.push({
              id: element.yearId,
              name: element.naziv
            });
          });
        })
        .catch((error) => {
          console.log(error);
        });
    },
    getStatus() {
      store
        .dispatch("status/GET_ALL")
        .then((response) => {
          this.statusDropdownOptions = [];
          response.data.status.forEach((element) => {
            this.statusDropdownOptions.push({
              id: element.statusId,
              name: element.naziv
            });
          });
        })
        .catch((error) => {
          console.log(error);
        });
    },
    getById() {
      store
        .dispatch("student/GET_BY_ID", this.$route.params.pkStudentID)
        .then((response) => {
          this.model = response.data.student;
          console.log(this.model);
        })
        .catch((error) => {});
    }
  },
  data() {
    return {
      model: {},
      statusDropdownOptions: [],
      statusDropdownDefault: { id: 0, name: "Izaberi" },
      godinaDropdownOptions: [],
      godinaDropdownDefault: { id: 0, name: "Izaberi" }
    };
  },
  created() {
    if (this.$route.params.pkStudentID) this.getById();
    this.getAllYears();
    this.getStatus();
  },
  watch: {
    statusDropdownOptions: function () {
      let status = this.statusDropdownOptions.find(
        (obj) => obj.id === this.model.statusId
      );

      this.statusDropdownDefault = Object.assign(
        {},
        this.statusDropdownDefault,
        status
      );
    },
    godinaDropdownOptions: function () {
      let godina = this.godinaDropdownOptions.find(
        (obj) => obj.id === this.model.yearId
      );

      this.godinaDropdownDefault = Object.assign(
        {},
        this.godinaDropdownDefault,
        godina
      );
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
  .title {
    font-size: 36px;
    text-align: left;
    margin-bottom: 30px;
  }
  .form-card {
    margin: 0 auto !important;
    text-align: center;
    background: #ffffff;
    box-shadow: 0px 4px 20px rgba(0, 0, 0, 0.15);
    border: none !important;
    width: 100%;
    min-height: calc(100vh - 200px);
    padding-bottom: 70px;
    h1 {
      font-family: "Roboto";
      font-style: normal;
      font-weight: 500;
      font-size: 30px;
      line-height: 38px;
      color: #000000;
      padding-top: 43px;
      margin-bottom: 96px;
    }
    .form-items {
      max-width: 395px;
      margin: 0 auto;
      .input-group {
        .eye-icon {
          position: absolute;
          right: 20px;
          // bottom: 20px;
          top: 48px;
          font-size: 9px;
          line-height: 9px;
          color: #6b6b6b;
          cursor: pointer;
        }
      }
    }
  }
}
</style>
