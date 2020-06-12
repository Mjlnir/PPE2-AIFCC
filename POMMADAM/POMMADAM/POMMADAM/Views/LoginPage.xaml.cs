using POMMADAM.Controllers;
using POMMADAM.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POMMADAM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        void SeConnecter(object sender, EventArgs e)
        {
            LoginController _clsLoginC = new LoginController();
            if (string.IsNullOrEmpty(txtLogin.Text) || string.IsNullOrEmpty(txtMdp.Text))
            {
                DisplayAlert("Erreur", "Le login ou le mot de passe doivent être renseignés.", "Ok");
            }
            else
            {
                User _user = _clsLoginC.Login(txtLogin.Text, txtMdp.Text);
                if (_user != null)
                {
                    App.isLoggedIn = true;
                    ((App)App.Current).Properties["LoggedUser"] = _user;
                    ((App)App.Current).PresentMainPage();
                }
                else
                {
                    DisplayAlert("Erreur", "Le login ou le mot de passe ne correspondent pas.", "Ok");
                }
            }
        }

        private void TxtMdp_Unfocused(object sender, FocusEventArgs e)
        {
            SeConnecter(this, EventArgs.Empty);
        }
    }
}