import globalStore from "../../store/index";

const student = {
    namespaced: true,
    state: {
    },
    actions: {
        CREATE: function({state},model) {
            return new Promise((resolve, reject) => {
              globalStore.state.$axios_auth
                .post("/api/student/", model)
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
                globalStore.state.$axios_auth
                    .get("/api/student/")
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
              globalStore.state.$axios_auth
                  .get("api/student/"+ id)
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
          globalStore.state.$axios_auth
            .put("/api/student/", model)
            .then(function(response) {
              resolve(response);
            })
            .catch(function(error) {
              reject(error.response);
            });
        });
      }, 
    },
    mutations: {
    }
};
export default student;
