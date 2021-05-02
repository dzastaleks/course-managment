<template>
  <div class="dashboard-container">
    <div class="grid-dashboard">
      <div class="header">
        <div class="title">Kursevi</div>
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
            this.$route.params.pkCourseId == null
              ? "Kreirajte novi kurs"
              : "Izmenite kurs"
          }}
        </h1>
        <form @submit.prevent data-vv-scope="course_form">
          <div class="form-items">
            <div class="input-group">
              <label for="naziv">Naziv Kursa: </label>
              <input
                v-validate="'required'"
                name="naziv"
                type="text"
                placeholder="Unesite Naziv novog kursa"
                :class="
                  errors.first('course_form.naziv') != null ? 'input-error' : ''
                "
                v-model="model.nazivKursa"
              />
            </div>

            <div>
              <btn
                :styleBtn="'primary'"
                :title="'Sačuvaj'"
                @click="submit()"
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
    submit() {
      this.$validator.validateAll("_form").then((valid) => {
        if (valid) {
          if (this.$route.params.pkCourseId == null) {
            store
              .dispatch("CREATE_COURSE", this.model)
              .then((response) => {
                this.$toastr.success("Kurs je dodat!", "Uspješno");
                console.log(response);
                this.$router.push({ name: "Course" });
              })
              .catch((error) => {
                this.message = error.data.message;
                this.$toastr.error(this.message, "Greška");

                console.log(error);
              });
          } else {
            store
              .dispatch("EDIT_COURSE", this.model)
              .then((response) => {
                console.log(this.model);
                this.$toastr.success("Kurs je izmijenjen!", "Uspješno");
                this.$router.push({ name: "Course" });
                console.log(response);
              })
              .catch((error) => {
                this.message = error.data.message;
                this.$toastr.error(this.message, "Greška");
                console.log(error);
              });
          }
        }
      });
    },
    getById() {
      store
        .dispatch("GET_BY_ID_COURSE", this.$route.params.pkCourseId)
        .then((response) => {
          this.model = response.data.course;
        })
        .catch((error) => {
          this.$toastr.error(error, "Greška");
        });
    }
  },
  data() {
    return {
      model: {
        nazivKursa: ""
      },
      message: ""
    };
  },
  created() {
    if (this.$route.params.pkCourseId) this.getById();
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
    height: calc(100vh - 200px);
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
