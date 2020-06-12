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
    public partial class Reserver : ContentPage
    {
        public event EventHandler RefreshListItems;

        public List<Vehicule> lstVehicules;
        public List<User> lstUsers;

        User userLogged = ((App)App.Current).Properties["LoggedUser"] as User;

        public Reserver(List<Vehicule> _lstVehicules, List<User> _lstUsers)
        {
            InitializeComponent();
            lstVehicules = _lstVehicules;
            lstUsers = _lstUsers;
            dpDateD.MinimumDate = DateTime.Now;
            dpDateF.MinimumDate = DateTime.Now;
            if (userLogged.Type > 2)
            {
                lblForUtilisateur.IsVisible = false;
                pckUtilisateur.IsVisible = false;
            }
            else
            {
                pckUtilisateur.ItemsSource = lstUsers;
            }
            pckVehicule.ItemsSource = lstVehicules;
        }

        private void ConfirmerReservation(object sender, System.EventArgs e)
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
            object _objReturn;
            if (userLogged.Type > 2)
            {
                _objReturn = _clsReservationController.Reserver(_iIdVehicule, _dtJour, _dtFin, userLogged.Id);
            }
            else
            {
                int _iIdUtilisateur = 0;
                foreach (User user in lstUsers)
                {
                    if (((User)pckUtilisateur.SelectedItem).Login == user.Login)
                    {
                        _iIdUtilisateur = user.Id;
                    }
                }
                _objReturn = _clsReservationController.Reserver(_iIdVehicule, _dtJour, _dtFin, _iIdUtilisateur);
            }
            if (!string.IsNullOrEmpty(_objReturn.ToString()) && RefreshListItems != null)
            {
                RefreshListItems(this, EventArgs.Empty);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Erreur", "Un problème est survenue lors de la reservation.", "Ok");
            }
        }
        private void AnnulerModif(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void TpDate_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (tpDateF.Time.ToString().Equals("00:00:00") || tpDateD.Time.ToString().Equals("00:00:00"))
            {
                return;
            }
            if (e.PropertyName == TimePicker.TimeProperty.PropertyName)
            {
                DateTime _dtJour = dpDateD.Date.Add(tpDateD.Time);
                DateTime _dtFin = dpDateF.Date.Add(tpDateF.Time);
                if (_dtJour > _dtFin)
                {
                    DisplayAlert("Erreur", "Revoyez vos dates, elles ne correspodent pas.", "Ok");
                }
                else
                {
                    pckVehicule.SelectedIndex = 0;
                    VehiculeController _clsVehiculeController = new VehiculeController();
                    List<Vehicule> _lstVehiculesByDate = _clsVehiculeController.GetVehiculesByDate(_dtJour, _dtFin);
                    pckVehicule.ItemsSource = _lstVehiculesByDate;
                }
            }

        }
    }
}