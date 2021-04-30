import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";

Vue.use(Vuex);
const $api ="https://localhost:44328/";

export default new Vuex.Store({
  state: {
    token:null,
    $axios: axios.create({
      baseURL: $api
    }),
    $axios_auth: axios.create({
      baseURL: $api
    }),
    user:null
  },
  mutations: {
    SET_TOKEN: function (state, token) {
      localStorage.setItem("token", token);
      state.token = token;
      if (state.$axios_auth) {
        state.$axios_auth.defaults.headers.common.Authorization = token;
      }
    },
    SET_USER: function (state, user) {
      localStorage.setItem("user", user);
      state.user = JSON.parse(user);
    },
    LOGOUT_USER: function (state) {
      localStorage.removeItem("user");
      localStorage.removeItem("token");
      state.token = null;
      state.user = null;
      state.$axios = axios.create({
        baseURL: $api
      })
    },
    SHOW_LOADER: function (state) {
      state.showLoader = true;
    },
    HIDE_LOADER: function (state) {
      state.showLoader = false;
    },
  },
  actions: {
    CREATE_COURSE: function({state},model) {
      return new Promise((resolve, reject) => {
          this.state.$axios_auth
              .post("/api/course/", model)
              .then(function(response) {
              resolve(response);
              })
              .catch(function(error) {
              reject(error.response);
              });
          });
    },
  GET_ALL_COURSE: function () {
      return new Promise((resolve, reject) => {
          this.state.$axios_auth
              .get("/api/course/")
              .then(function (response) {
                  resolve(response);
              })
              .catch(function (error) {
                  reject(error.response);
              });
      });
  },
  GET_BY_ID_COURSE: function ({ state }, id) {
      return new Promise((resolve, reject) => {
          this.state.$axios_auth
              .get("api/course/"+ id)
              .then(function (response) {
                  resolve(response);
              })
              .catch(function (error) {
                  reject(error.response);
              });
      });
  },
  EDIT_COURSE: function({state},model) {
    return new Promise((resolve, reject) => {
      this.state.$axios_auth
          .put("/api/course/", model)
          .then(function(response) {
              resolve(response);
          })
          .catch(function(error) {
              reject(error.response);
          });
      });
  }, 
  GET_DETAILS_COURSE: function ({ state }, id) {
    return new Promise((resolve, reject) => {
        this.state.$axios_auth
            .get("api/course/get-details-for-course/"+ id)
            .then(function (response) {
                resolve(response);
            })
            .catch(function (error) {
                reject(error.response);
            });
    });
},
GET_STUDENTS_NOT_IN_COURSE: function ({ state }, id) {
  return new Promise((resolve, reject) => {
      this.state.$axios_auth
          .get("api/course/get-students-not-in-course/"+ id)
          .then(function (response) {
              resolve(response);
          })
          .catch(function (error) {
              reject(error.response);
          });
  });
},
SAVE_STUDENTS_COURSE: function ({ state }, model) {
return new Promise((resolve, reject) => {
  this.state.$axios_auth
        .post("api/course/add-selected-students-to-course", model)
        .then(function (response) {
            resolve(response);
        })
        .catch(function (error) {
            reject(error.response);
        });
});
},
DELETE_STUDENTS_COURSE: function ({ state }, model) {
  return new Promise((resolve, reject) => {
      this.state.$axios_auth
          .post("api/course/delete-selected-students-from-course", model)
          .then(function (response) {
              resolve(response);
          })
          .catch(function (error) {
              reject(error.response);
          });
  });
},
GET_STUDENTS_COURSE: function ({ state }, id) {
  return new Promise((resolve, reject) => {
      this.state.$axios_auth
          .get("api/course/get-students-for-course/"+ id)
          .then(function (response) {
              resolve(response);
          })
          .catch(function (error) {
              reject(error.response);
          });
  });
},
LOGIN: function ({ state }, model) {
  return new Promise((resolve, reject) => {
      this.state.$axios
          .post("api/user/authenticate", model)
          .then(function (response) {
              resolve(response);
          })
          .catch(function (error) {
              reject(error.response);
          });
  });
},
LOGOUT: function ({ state }, model) {
  return new Promise((resolve, reject) => {
      this.state.$axios_auth
          .post("api/user/logout-user", { refreshToken: model })
          .then(function (response) {
              resolve(response);
          })
          .catch(function (error) {
              reject(error.response);
          });
  });
},
GET_ALL_STATUS: function () {
  return new Promise((resolve, reject) => {
      this.state.$axios_auth
          .get("/api/status/")
          .then(function (response) {
              resolve(response);
          })
          .catch(function (error) {
              reject(error.response);
          });
  });
},
CREATE_STUDENT: function({state},model) {
  return new Promise((resolve, reject) => {
    this.state.$axios_auth
      .post("/api/student/", model)
      .then(function(response) {
        resolve(response);
      })
      .catch(function(error) {
        reject(error.response);
      });
  });
},
GET_ALL_STUDENT: function () {
  return new Promise((resolve, reject) => {
     this.state.$axios_auth
          .get("/api/student/")
          .then(function (response) {
              resolve(response);
          })
          .catch(function (error) {
              reject(error.response);
          });
  });
},
GET_BY_ID_STUDENT: function ({ state }, id) {
return new Promise((resolve, reject) => {
  this.state.$axios_auth
        .get("api/student/"+ id)
        .then(function (response) {
            resolve(response);
        })
        .catch(function (error) {
            reject(error.response);
        });
  });
},
EDIT_STUDENT: function({state},model) {
  return new Promise((resolve, reject) => {
      this.state.$axios_auth
          .put("/api/student/", model)
          .then(function(response) {
              resolve(response);
          })
          .catch(function(error) {
              reject(error.response);
          });
      });
}, 
GET_DETAILS_STUDENT: function ({ state }, id) {
  return new Promise((resolve, reject) => {
      this.state.$axios_auth
          .get("api/student/get-details-for-student/"+ id)
          .then(function (response) {
              resolve(response);
          })
          .catch(function (error) {
              reject(error.response);
          });
  });
},
GET_COURSES_STUDENT: function ({ state }, id) {
  return new Promise((resolve, reject) => {
      this.state.$axios_auth
          .get("api/student/get-courses-for-student/"+ id)
          .then(function (response) {
              resolve(response);
          })
          .catch(function (error) {
              reject(error.response);
          });
  });
},
CREATE_YEAR: function({state},model) {
      return new Promise((resolve, reject) => {
          this.state.$axios_auth
              .post("/api/year/", model)
              .then(function(response) {
              resolve(response);
              })
              .catch(function(error) {
              reject(error.response);
              });
          });
    },
  GET_ALL_YEAR: function ({state}) {
      return new Promise((resolve, reject) => {
          this.state.$axios_auth
              .get("/api/year/")
              .then(function (response) {
                  resolve(response);
              })
              .catch(function (error) {
                  reject(error.response);
              });
      });
  },
  GET_BY_ID_YEAR: function ({ state }, id) {
    return new Promise((resolve, reject) => {
      this.state.$axios_auth
            .get("api/year/"+ id)
            .then(function (response) {
                resolve(response);
            })
            .catch(function (error) {
                reject(error.response);
            });
    });
},
EDIT_YEAR: function({state},model) {
  return new Promise((resolve, reject) => {
      this.state.$axios_auth
          .put("/api/year/", model)
          .then(function(response) {
          resolve(response);
          })
          .catch(function(error) {
          reject(error.response);
          });
      });
}, 
  },
});
