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
	public partial class VehiculePage : ContentPage
	{
		public VehiculePage ()
		{
			InitializeComponent ();
            lstVehicules.HasUnevenRows = true;
            VehiculeController _clsVehiculeController = new VehiculeController();

            List<Vehicule> _lstVehicules = ((App)App.Current).Properties["Vehicules"] as List<Vehicule>;
            if (_lstVehicules != null)
            {
                lstVehicules.ItemsSource = _lstVehicules;
            }
            else
            {
                DisplayAlert("Erreur", "Le login ou le mot de passe ne correspondent pas.", "Ok");
            }
        }
	}
}