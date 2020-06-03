<template>
    <Page>
        <!-- Titre -->
        <ActionBar title="POMMADAM" />
        <!-- Page de formulaire -->
        <FlexboxLayout class="page">
            <!-- Form -->
            <StackLayout class="form">
                <Image class="logo" src="~/public/image/logo.png" />
                <Label class="header" text="POMMADAM" />

                <!-- Layout contenant le login, mdp, cmdp et le submit value button -->
                <StackLayout class="input-field" marginBottom="25">
                    <Label text="Login" />
                    <TextField class="input" hint="jbonneau"
                        keyboardType="text" autocorrect="false"
                        autocapitalizationType="none" v-model="user.login"
                        returnKeyType="next" 
                        fontSize="18" />

                    <StackLayout class="input-field" marginBottom="25">
                        <Label text="Mot de passe" />
                        <TextField ref="password" class="input"
                            hint="Mot de passe" secure="true"
                            v-model="user.password"
                            returnKeyType="done"
                            fontSize="18" />
                        <StackLayout class="hr-light" />
                    </StackLayout>

                    <Button
                        text="Se connecter"
                        @tap="submit" class="btn btn-primary m-t-20" />
                </StackLayout>
            </StackLayout>
        </FlexboxLayout>
    </Page>
</template>

<script>
    import Reserve from './Reserve';
    const LoginAPI = require("~/controllers/LoginController.js").LoginAPI;
    const applicationSettings = require('tns-core-modules/application-settings');
    export default {
         data() {
            return {
                user: {
                    login: "",
                    password: ""
                },
                routes: {
                    cal: Reserve
                }
            };
        },
        methods: {
            submit() {
                if (!this.user.login || !this.user.password) {
                    alert("Entrez un login et un mot de passe.");
                    return;
                }
                else {
                    LoginAPI.Login(this.user).then(function(result){
                        if (result["nbUtilisateur"] == "1") {
                            applicationSettings.setString("Log", result["nbUtilisateur"]);
                            applicationSettings.setString("TypeUser", result["idTypeUtilisateur"]);
                            goTo('cal');
                        }
                        else{
                            alert("Mauvais Login ou mot de passe.");
                        }
                    });
                }
            },
            goTo(s) {
                this.$navigateTo(this.routes[s]);
            }
        }
    };
</script>

<style scoped>
    .page {
        align-items: center;
        flex-direction: column;
    }

    .form {
        margin-left: 30;
        margin-right: 30;
        flex-grow: 2;
        vertical-align: middle;
    }

    .logo {
        margin-bottom: 12;
        height: 90;
        font-weight: bold;
    }

    .header {
        horizontal-align: center;
        font-size: 25;
        font-weight: 600;
        margin-bottom: 70;
        text-align: center;
        color: #D51A1A;
    }

    .input-field {
        margin-bottom: 25;
    }

    .input {
        font-size: 18;
        placeholder-color: #A8A8A8;
    }

    .input-field .input {
        font-size: 54;
    }

    .btn-primary {
        height: 50;
        margin: 30 5 15 5;
        background-color: #D51A1A;
        border-radius: 5;
        font-size: 20;
        font-weight: 600;
    }

    .login-label {
        horizontal-align: center;
        color: #A8A8A8;
        font-size: 16;
    }

    .sign-up-label {
        margin-bottom: 20;
    }

    .bold {
        color: #000000;
    }
</style>