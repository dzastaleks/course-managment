import globalStore from "../../store/index";

const course = {
    namespaced: true,
    state: {
    },
    actions: {
        CREATE: function({state},model) {
            return new Promise((resolve, reject) => {
              globalStore.state.$axios
                .post("/api/course/", model)
                .then(function(response) {
                  resolve(response);
                })
                .catch(function(error) {
                  reject(error.response);
                });
            });
          },
        GET_ALL: function () {
            return new Promise((resolve, reject) => {
                globalStore.state.$axios
                    .get("/api/course/")
                    .then(function (response) {
                        resolve(response);
                    })
                    .catch(function (error) {
                        reject(error.response);
                    });
            });
        },
        GET_BY_ID: function ({ state }, id) {
            return new Promise((resolve, reject) => {
                globalStore.state.$axios
                    .get("api/course/"+ id)
                    .then(function (response) {
                        resolve(response);
                    })
                    .catch(function (error) {
                        reject(error.response);
                    });
            });
        },
        EDIT: function({state},model) {
          return new Promise((resolve, reject) => {
            globalStore.state.$axios
              .put("/api/course/", model)
              .then(function(response) {
                resolve(response);
              })
              .catch(function(error) {
                reject(error.response);
              });
          });
        }, 
        GET_DETAILS: function ({ state }, id) {
          return new Promise((resolve, reject) => {
              globalStore.state.$axios_auth
                  .get("api/course/get-details-for-course/"+ id)
                  .then(function (response) {
                      resolve(response);
                  })
                  .catch(function (error) {
                      reject(error.response);
                  });
          });
      },
      GET_STUDENTS_NOT_IN: function ({ state }, id) {
        return new Promise((resolve, reject) => {
            globalStore.state.$axios
                .get("api/course/get-students-not-in-course/"+ id)
                .then(function (response) {
                    resolve(response);
                })
                .catch(function (error) {
                    reject(error.response);
                });
        });
    },
    SAVE_STUDENTS: function ({ state }, model) {
      return new Promise((resolve, reject) => {
          globalStore.state.$axios_auth
              .post("api/course/add-selected-students-to-course", model)
              .then(function (response) {
                  resolve(response);
              })
              .catch(function (error) {
                  reject(error.response);
              });
      });
    },
    DELETE_STUDENTS: function ({ state }, model) {
        return new Promise((resolve, reject) => {
            globalStore.state.$axios_auth
                .post("api/course/delete-selected-students-from-course", model)
                .then(function (response) {
                    resolve(response);
                })
                .catch(function (error) {
                    reject(error.response);
                });
        });
      },
    GET_STUDENTS: function ({ state }, id) {
        return new Promise((resolve, reject) => {
            globalStore.state.$axios_auth
                .get("api/course/get-students-for-course/"+ id)
                .then(function (response) {
                    resolve(response);
                })
                .catch(function (error) {
                    reject(error.response);
                });
        });
      },
      
    },
    mutations: {
    }
};
export default course;
