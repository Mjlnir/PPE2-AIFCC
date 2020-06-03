using POMMADAM.Controllers;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using POMMADAM.Models;
using POMMADAM.ViewsModels;
using System;

namespace POMMADAM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationPage : ContentPage
    {
        ReservationController clsReservationController = new ReservationController();
        VehiculeController clsVehiculeController = new VehiculeController();
        UserController clsUserController = new UserController();
        List<Reservation> clstReservations = ((App)App.Current).Properties["Reservations"] as List<Reservation>;
        List<Vehicule> lstVehicules = ((App)App.Current).Properties["Vehicules"] as List<Vehicule>;
        List<User> lstUsers = ((App)App.Current).Properties["Users"] as List<User>;
        User _user = ((App)App.Current).Properties["LoggedUser"] as User;

        public ReservationPage()
        {
            InitializeComponent();

            lstReservations.HasUnevenRows = true;
            if (clstReservations != null)
            {
                SetListItems(false);
            }
            else
            {
                DisplayAlert("Erreur", "Problème d'appel à la base de données.", "Ok");
            }
        }

        public void SetListItems(bool _blRefresh)
        {
            if (_blRefresh)
            {
                clstReservations = clsReservationController.GetReservations();
            }
            List<ReservationModel> _lstReservationModel = new List<ReservationModel>();
            foreach (Reservation _res in clstReservations)
            {
                _lstReservationModel.Add(new ReservationModel(
                    _res.Id
                    , clsVehiculeController.GetNomVehicule(lstVehicules, _res.IdVehicule)
                    , clsUserController.GetNomUser(lstUsers, _res.IdUtilisateur)
                    , _res.JourReservation
                    , _res.HeureFin
                    , _res.IdUtilisateur == _user.Id ? true : false
                    ));
            }
            lstReservations.ItemsSource = _lstReservationModel;
        }

        private void LstReservations_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            ReservationModel item = e.SelectedItem as ReservationModel;
            Reservation _rSelected = new Reservation();
            foreach (Reservation _res in clstReservations)
            {
                if (_res.Id == item.IdReservation)
                {
                    _rSelected = _res;
                }
            }
            var ModifReservation = new ModifReservation(_rSelected, lstVehicules);
            ModifReservation.RefreshListItems += ModifReservation_RefreshListItems;

            Navigation.PushAsync(ModifReservation);
        }

        private void ModifReservation_RefreshListItems(object sender, EventArgs e)
        {
            SetListItems(true);
        }

        private void Reserver(object sender, EventArgs e)
        {
            var Reserver = new Reserver(lstVehicules);
            Reserver.RefreshListItems += ModifReservation_RefreshListItems;

            Navigation.PushAsync(Reserver);
        }
    }
}