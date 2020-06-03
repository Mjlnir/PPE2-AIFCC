const axios = require('axios');
const applicationSettings = require('tns-core-modules/application-settings');
const LoginAPI = {
    Login: function (user) {
        return axios({
            method: 'post',
            url: applicationSettings.getString("API_NGROK") + applicationSettings.getString("API_LoginController") + "login",
            data: {
                username: user.login,
                password: user.password
            }
        }).then(function (response) {
            // handle success
            return response.data;
        })
        .catch(function (error) {
            // handle error
            return "Error: " + error;
        });
    },
    Register: function (user) {
        if (user.password != user.confirmPassword) {
            alert("Vos mots de passe ne correspondent pas.");
            return;
        }
    }
}
exports.LoginAPI = LoginAPI;

