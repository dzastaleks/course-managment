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
    },
    mutations: {
    }
};
export default course;
