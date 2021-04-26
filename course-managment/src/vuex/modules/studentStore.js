import globalStore from "../../store/index";

const student = {
    namespaced: true,
    state: {
    },
    actions: {
        CREATE: function({state},model) {
            return new Promise((resolve, reject) => {
              globalStore.state.$axios
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
                globalStore.state.$axios
                    .get("/api/student/")
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
export default student;
