<template>
  <div class="dashboard-container">
    <div class="grid-dashboard">
      <div class="title">Novi Kurs</div>
      <div class="form-card">
        <h1>Kreirajte novi kurs</h1>
        <div class="form-items">
          <div class="input-group">
            <label for="naziv">Naziv Kursa: </label>
            <input
              type="text"
              placeholder="Unesite Naziv novog kursa"
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
      </div>
    </div>
  </div>
</template>

<script>
import store from "@/store/index";

export default {
  components: {},
  methods: {
    submit() {
      if (this.$route.params.pkCourseId == null) {
        store
          .dispatch("course/CREATE", this.model)
          .then((response) => {
            console.log(response);
          })
          .catch((error) => {
            console.log(error);
          });
      } else {
        store
          .dispatch("course/EDIT", this.model)
          .then((response) => {
            console.log(this.model);
            console.log(response);
          })
          .catch((error) => {
            console.log(error);
          });
      }
    },
    getById() {
      store
        .dispatch("course/GET_BY_ID", this.$route.params.pkCourseId)
        .then((response) => {
          this.model = response.data.course;
        })
        .catch((error) => {});
    }
  },
  data() {
    return {
      model: {
        nazivKursa: ""
      }
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
