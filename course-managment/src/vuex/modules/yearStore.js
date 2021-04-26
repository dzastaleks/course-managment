import globalStore from "../../store/index";

const year = {
    namespaced: true,
    state: {
    },
    actions: {
        CREATE: function( model) {
            return new Promise((resolve, reject) => {
              globalStore.state.$axios
                .post("/api/year/", model)
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
                    .get("/api/year/")
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
export default year;
