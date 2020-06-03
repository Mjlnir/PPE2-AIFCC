using POMMADAM.Controllers;
using POMMADAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POMMADAM.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UtilisateurPage : ContentPage
	{
		public UtilisateurPage ()
		{
			InitializeComponent ();
            lstUsers.HasUnevenRows = true;
            UserController _clsUserController = new UserController();

            List<User> _lstUsers = ((App)App.Current).Properties["Users"] as List<User>;
            if (_lstUsers != null)
            {
                lstUsers.ItemsSource = _lstUsers;
            }
            else
            {
                DisplayAlert("Erreur", "Le login ou le mot de passe ne correspondent pas.", "Ok");
            }
        }
	}
}