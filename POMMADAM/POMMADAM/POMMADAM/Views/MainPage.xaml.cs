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
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            ReservationController _clsReservationController = new ReservationController();
            TypeVehiculeController _clsTypeVehiculeController = new TypeVehiculeController();
            VehiculeController _clsVehiculeController = new VehiculeController();
            TypeUtilisateurController _clsTypeUtilisateurController = new TypeUtilisateurController();
            UserController _clsUserController = new UserController();
            ((App)App.Current).Properties["Reservations"] = _clsReservationController.GetReservations();
            ((App)App.Current).Properties["TypesVehicules"] = _clsTypeVehiculeController.GetTypesVehicules();
            ((App)App.Current).Properties["Vehicules"] = _clsVehiculeController.GetVehicules();
            ((App)App.Current).Properties["TypesUtilisateurs"] = _clsTypeUtilisateurController.GetTypesUtilisateurs();
            ((App)App.Current).Properties["Users"] = _clsUserController.GetUsers();
            InitializeComponent();
        }

    }
}