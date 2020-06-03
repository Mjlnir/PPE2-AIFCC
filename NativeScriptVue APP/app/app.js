import Vue from 'nativescript-vue';
import Main from './views/Main';
import Login from './views/Login';

// Uncommment the following to see NativeScript-Vue output logs
Vue.config.silent = false;
const applicationSettings = require('tns-core-modules/application-settings');
applicationSettings.setString("API_NGROK", "https://c8aec1ed.ngrok.io/");
applicationSettings.setString("API_LoginController", "PPE2-AIFCC/API/controllers/loginController.php?action=");
new Vue({
    render: h => h(Main)
}).$start();