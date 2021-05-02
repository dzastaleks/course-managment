<template>
  <div class="login-container">
    <div class="logo">
      <img
        class="logo-img"
        :src="require(`../../assets/img/logo.png`)"
        alt=""
      />
    </div>
    <div class="form-card">
      <h1>Login</h1>
      <form @submit.prevent data-vv-scope="login_form">
        <div class="form-items">
          <div class="input-group">
            <label for="username">Korisnicko ime: </label>
            <input
              v-validate="'required'"
              type="text"
              name="username"
              v-model="model.username"
              :class="
                errors.first('login_form.username') != null ? 'input-error' : ''
              "
              placeholder="Unesite Korisnicko ime"
            />
          </div>
          <div class="input-group">
            <label for="password">Lozinka: </label>
            <input
              v-validate="'required'"
              :type="typePassword"
              name="lozinka"
              v-model="model.password"
              :class="
                errors.first('login_form.lozinka') != null ? 'input-error' : ''
              "
              placeholder="Unesite Lozinku"
            />
            <i class="icon-eye eye-icon" v-on:click="showHidePass"></i>
          </div>
          <div>
            <btn :styleBtn="'primary'" :title="'Login'" @click="login()"></btn>
          </div>
        </div>
      </form>
    </div>
    <div class="footer">
      <div class="footer-title">
        {{ "Course Managment System" }}
      </div>
      <div class="footer-year">
        {{ "2021" }}
      </div>
    </div>
  </div>
</template>
<script>
import store from "@/store/index";

export default {
  data() {
    return {
      typePassword: "password",
      model: {
        username: "",
        password: ""
      },
      message: ""
    };
  },
  created() {
    localStorage.clear();
  },
  methods: {
    showHidePass() {
      this.typePassword = this.typePassword == "password" ? "text" : "password";
    },
    login() {
      this.$validator.validateAll("login_form").then((valid) => {
        if (valid) {
          console.log("login");
          var $this = this;
          store
            .dispatch("LOGIN", this.model)
            .then((response) => {
              store.commit("SET_TOKEN", "Bearer " + response.data.token);
              store.commit("SET_USER", JSON.stringify(response.data));
              if (localStorage.getItem("user")) {
                var user = JSON.parse(localStorage.getItem("user"));
                $this.$router.push({ name: "DashboardIndex" });
                console.log(response.data);
              }
            })
            .catch((error) => {
              this.message = error.data.message;
              this.$toastr.error(this.message, "Greška");

              console.log(error);
            })
            .finally(() => {});
        }
      });
    }
  }
};
</script>

<style lang="scss" scoped>
.login-container {
  .logo {
    img.logo-img {
      width: 200px;
      margin-top: 40px;
      text-align: center;
      margin-bottom: 52px;
    }
  }
  .form-card {
    margin: 0 auto !important;
    text-align: center;
    background: #ffffff;
    box-shadow: 0px 4px 20px rgba(0, 0, 0, 0.15);
    border: none !important;
    width: 610px;
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
  .footer {
    text-align: center;
    font-family: "Roboto", sans-serif;
    color: #444444;
    font-style: normal;
    font-weight: 500;
    text-align: center;
    margin-top: 60px;
    &-title {
      font-size: 18px;
      line-height: 21px;
    }
    &-year {
      font-size: 12px;
      line-height: 14px;
    }
  }
}
</style>
