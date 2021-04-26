import globalStore from "../../store/index";

const student = {
    namespaced: true,
    state: {
    },
    actions: {
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
