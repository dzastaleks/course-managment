import globalStore from "../../store/index";

const login = {
    namespaced: true,
    state: {
    },
    actions: {
        LOGIN: function ({ state }, model) {
            return new Promise((resolve, reject) => {
                globalStore.state.$axios
                    .post("api/user/authenticate", model)
                    .then(function (response) {
                        resolve(response);
                    })
                    .catch(function (error) {
                        reject(error.response);
                    });
            });
        },
        LOGOUT_USER: function ({ state }, model) {
            return new Promise((resolve, reject) => {
                globalStore.state.$axios_auth
                    .post("api/user/logout-user", { refreshToken: model })
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
export default login;
