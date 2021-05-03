<template>
  <div class="dashboard-container">
    <div class="grid-dashboard">
      <div class="header">
        <div class="title">Studenti</div>
        <btn
          :styleBtn="'primary'"
          :title="'Nazad'"
          :icon="'solid-arrow-left'"
          style="margin-bottom: 0px !important"
          @click="goBack()"
        ></btn>
      </div>
      <div class="form-card">
        <h1>
          {{
            this.$route.params.pkStudentID == null
              ? "Dodajte novog studenta"
              : "Izmenite studenta"
          }}
        </h1>
        <form @submit.prevent data-vv-scope="student_form">
          <div class="form-items">
            <div class="input-group">
              <label for="ime">Ime: </label>
              <input
                v-validate="'required'"
                name="ime"
                type="text"
                placeholder="Unesite Ime studenta"
                v-model="model.ime"
                :class="
                  errors.first('student_form.ime') != null ? 'input-error' : ''
                "
              />
            </div>
            <div class="input-group">
              <label for="prezime">Prezime: </label>
              <input
                v-validate="'required'"
                name="prezime"
                type="text"
                placeholder="Unesite Prezime studenta"
                v-model="model.prezime"
                :class="
                  errors.first('student_form.prezime') != null
                    ? 'input-error'
                    : ''
                "
              />
            </div>
            <div class="input-group">
              <label for="brojIndeksa">Broj Indeksa: </label>
              <input
                v-validate="'required'"
                name="brojIndeksa"
                type="text"
                placeholder="Unesite Broj indeksa studenta"
                v-model="model.brojIndeksa"
                :class="
                  errors.first('student_form.brojIndeksa') != null
                    ? 'input-error'
                    : ''
                "
              />
            </div>
            <div class="input-group">
              <label for="Godina">Godina:</label>
              <dropdown
                v-validate="'dropdown-required'"
                :options="godinaDropdownOptions"
                :default="godinaDropdownDefault"
                @input="handleDropdownYear"
                :tabindex="1"
                name="godina"
                v-model="model.yearId"
                :errorClass="
                  errors.first('student_form.godina') != null
                    ? 'input-error'
                    : ''
                "
              ></dropdown>
            </div>
            <div class="input-group">
              <label for="Status">Status:</label>
              <dropdown
                v-validate="'dropdown-required'"
                :options="statusDropdownOptions"
                :default="statusDropdownDefault"
                @input="handleDropdownStatus"
                :tabindex="2"
                name="status"
                v-model="model.statusId"
                :errorClass="
                  errors.first('student_form.status') != null
                    ? 'input-error'
                    : ''
                "
              ></dropdown>
            </div>
            <div>
              <btn
                :styleBtn="'primary'"
                :title="'Sačuvaj'"
                @click="save()"
              ></btn>
            </div>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import store from "@/store/index";

export default {
  components: {},
  methods: {
    redirectToComponent(component) {
      if (this.$route.name == component) return;
      this.$router.push({ name: component });
    },
    goBack() {
      this.$router.go(-1);
    },
    handleDropdownStatus(value) {
      this.model.statusId = value;
    },
    handleDropdownYear(value) {
      this.model.yearId = value;
    },
    save() {
      this.$validator.validateAll("student_form").then((valid) => {
        if (valid) {
          if (this.$route.params.pkStudentID == null) {
            store
              .dispatch("CREATE_STUDENT", this.model)
              .then((response) => {
                this.$toastr.success("Student je dodat!", "Uspješno");
                this.$router.push({ name: "Student" });
              })
              .catch((error) => {
                this.$toastr.error(error.data.message, "Greška");
              });
          } else {
            store
              .dispatch("EDIT_STUDENT", this.model)
              .then((response) => {
                this.$toastr.success("Student je izmijenjen!", "Uspješno");
                this.$router.push({ name: "Student" });
              })
              .catch((error) => {
                this.$toastr.error(error.data.message, "Greška");
              });
          }
        }
      });
    },
    getAllYears() {
      store
        .dispatch("GET_ALL_YEAR")
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
          this.$toastr.error(error, "Greška");
        });
    },
    getStatus() {
      store
        .dispatch("GET_ALL_STATUS")
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
          this.$toastr.error(error, "Greška");
        });
    },
    getById() {
      store
        .dispatch("GET_BY_ID_STUDENT", this.$route.params.pkStudentID)
        .then((response) => {
          this.model = response.data.student;
        })
        .catch((error) => {
          this.$toastr.error(error, "Greška");
        });
    }
  },
  data() {
    return {
      model: {
        statusId: 0,
        yearId: 0
      },
      statusDropdownOptions: [],
      statusDropdownDefault: { id: 0, name: "Izaberi" },
      godinaDropdownOptions: [],
      godinaDropdownDefault: { id: 0, name: "Izaberi" },
      message: ""
    };
  },
  created() {
    if (this.$route.params.pkStudentID) this.getById();
    this.getAllYears();
    this.getStatus();
  },
  watch: {
    model: function () {
      let status = this.statusDropdownOptions.find(
        (obj) => obj.id === this.model.statusId
      );

      this.statusDropdownDefault = Object.assign(
        {},
        this.statusDropdownDefault,
        status
      );
      let godina = this.godinaDropdownOptions.find(
        (obj) => obj.id === this.model.yearId
      );

      this.godinaDropdownDefault = Object.assign(
        {},
        this.godinaDropdownDefault,
        godina
      );
    },
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
    }
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
