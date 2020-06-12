using POMMADAM.Controllers;
using POMMADAM.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POMMADAM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ModifReservation : ContentPage
	{
        Reservation rSelected;
        List<Vehicule> lstVehicules;
        public event EventHandler RefreshListItems;
        public ModifReservation (Reservation res, List<Vehicule> _lstVehicules)
		{
            InitializeComponent ();

            rSelected = res;
            lstVehicules = _lstVehicules;
            pckVehicule.ItemsSource = lstVehicules;
            pckVehicule.SelectedIndex = rSelected.IdVehicule - 1;
            Title = "Modifcation de la réservation n°" + rSelected.Id;
            dpDateD.Date = rSelected.JourReservation.Date;
            dpDateD.MinimumDate = DateTime.Now;
            tpDateD.Time = rSelected.JourReservation.TimeOfDay;

            dpDateF.Date = rSelected.HeureFin.Date;
            dpDateF.MinimumDate = DateTime.Now;
            tpDateF.Time = rSelected.HeureFin.TimeOfDay;
        }

        private void ConfirmerModif(object sender, System.EventArgs e)
        {
            ReservationController _clsReservationController = new ReservationController();

            DateTime _dtJour = dpDateD.Date.Add(tpDateD.Time);
            DateTime _dtFin = dpDateF.Date.Add(tpDateF.Time);
            int _iIdVehicule = 0;
            if (pckVehicule.SelectedIndex == -1)
            {
                DisplayAlert("Erreur", "Veuillez sélectionner un véhicule.", "Ok");
                return;
            }
            foreach (Vehicule vc in lstVehicules)
            {
                if (((Vehicule)pckVehicule.SelectedItem).Nom == vc.Nom)
                {
                    _iIdVehicule = vc.Id;
                }
            }
            List<Reservation> _lstReservationsByDate = _clsReservationController.GetReservationsByDate(_dtJour, _dtFin, _iIdVehicule);
            if (_dtJour > _dtFin)
            {
                DisplayAlert("Erreur", "Revoyez vos dates, elles ne correspondent pas.","Ok");
                return;
            }
            else if (_lstReservationsByDate.Count > 0)
            {
                DisplayAlert("Erreur", "Revoyez vos dates, une réservation à déjà été émise pour ce véhicule à cette période.", "Ok");
                return;
            }
            object _objReturn = _clsReservationController.ModifReservation(rSelected.Id, _iIdVehicule, _dtJour,_dtFin);
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
            ReservationController _clsReservationController = new ReservationController();
            _clsReservationController.DeleteReservation(rSelected.Id);
            if (RefreshListItems != null)
            {
                RefreshListItems(this, EventArgs.Empty);
            }
            Navigation.PopAsync();
        }
    }
}