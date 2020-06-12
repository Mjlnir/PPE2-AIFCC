using POMMADAM.Controllers;
using POMMADAM.Models;
using POMMADAM.ViewsModels;
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
	public partial class ModifVehicule : ContentPage
	{
        Vehicule vcSelected;
        List<TypeVehicule> lstTypesVehicules;

        bool blEstDispo = false;
        public event EventHandler RefreshListItems;
        public ModifVehicule(Vehicule vc, List<TypeVehicule> _lstTypesVehicules)
        {
            InitializeComponent();
            vcSelected = vc;
            lstTypesVehicules = _lstTypesVehicules;

            txtNom.Text = vc.Nom;
            txtKm.Text = vc.Kilometrage.ToString();
            if (vc.IdTypeVehicule == 1)
            {
                lblNbPlace.IsVisible = false;
                txtNbPlace.IsVisible = false;
            }
            txtNbPlace.Text = vc.NbPlace.ToString();
            swEstDispo.IsToggled = vc.estDisponible == 1 ? true : false;
            pckTypeV.ItemsSource = _lstTypesVehicules;
            pckTypeV.SelectedIndex = vcSelected.IdTypeVehicule - 1;
            Title = "Modifcation du véhicule n°" + vcSelected.Id;
        }

        private void SwEstDispo_Toggled(object sender, ToggledEventArgs e)
        {
            blEstDispo = e.Value;
        }

        private void ConfirmerModif(object sender, System.EventArgs e)
        {
            VehiculeController _clsVehiculeController = new VehiculeController();
            int _iTypeIdVehicule = 0;
            if (pckTypeV.SelectedIndex == -1)
            {
                DisplayAlert("Erreur", "Veuillez sélectionner un type de véhicule.", "Ok");
                return;
            }
            foreach (TypeVehicule _tvc in lstTypesVehicules)
            {
                if (((TypeVehicule)pckTypeV.SelectedItem).NomTypeVehicule == _tvc.NomTypeVehicule)
                {
                    _iTypeIdVehicule = _tvc.Id;
                }
            }
            bool _NbPaceTest = vcSelected.IdTypeVehicule == 1 ? true : false;
            if (string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtKm.Text) || _NbPaceTest)
            {
                DisplayAlert("Erreur", "Veuillez les champs, Nom, Kilométrage et Nombre de place ne doivent pas êtres nuls.", "Ok");
                return;
            }
            object _objReturn = _clsVehiculeController.ModifVehicule(
                vcSelected.Id
                , txtNom.Text
                , Convert.ToInt32(txtKm.Text)
                , _iTypeIdVehicule == 1 ? Convert.ToInt32(txtNbPlace.Text) : 0
                , blEstDispo ? 1 : 0
                , _iTypeIdVehicule);
            if (!string.IsNullOrEmpty(_objReturn.ToString()) && RefreshListItems != null)
            {
                RefreshListItems(this, EventArgs.Empty);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Erreur", "Un problème est survenue lors de la modification.", "Ok");
            }
        }
        private void AnnulerModif(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
        private void Supprimer(object sender, System.EventArgs e)
        {
            VehiculeController _clsVehiculeController = new VehiculeController();
            _clsVehiculeController.DeleteVehicule(vcSelected.Id);
            if (RefreshListItems != null)
            {
                RefreshListItems(this, EventArgs.Empty);
            }
            Navigation.PopAsync();
        }

        private void PckTypeV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            TypeVehicule cvModelSelected = (TypeVehicule)picker.SelectedItem;
            if (cvModelSelected.NomTypeVehicule != "Voiture")
            {
                lblNbPlace.IsVisible = false;
                txtNbPlace.IsVisible = false;
            }
            else
            {
                lblNbPlace.IsVisible = true;
                txtNbPlace.IsVisible = true;
            }
        }

        private void PckTypeV_Unfocused(object sender, FocusEventArgs e)
        {
            txtKm.Focus();
        }
    }
}