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
    public partial class VehiculePage : ContentPage
    {
        VehiculeController clsVehiculeController = new VehiculeController();
        UserController clsUserController = new UserController();
        List<TypeVehicule> lstTypeVehicule = ((App)App.Current).Properties["TypesVehicules"] as List<TypeVehicule>;
        List<Vehicule> clsVehicules = ((App)App.Current).Properties["Vehicules"] as List<Vehicule>;
        List<User> clsUsers = ((App)App.Current).Properties["Users"] as List<User>;
        User user = ((App)App.Current).Properties["LoggedUser"] as User;

        public VehiculePage()
        {
            InitializeComponent();
            if (user.Type < 3)
            {
                lblVehicule.IsVisible = true;
                lstVehicules.IsVisible = true;
                lblDroit.IsVisible = false;
                btnAddVehicule.IsVisible = true;
                lstVehicules.HasUnevenRows = true;
                SetListItems(false);
            }
        }

        public void SetListItems(bool _blRefresh)
        {
            if (_blRefresh)
            {
                clsVehicules = clsVehiculeController.GetVehicules();
            }
            List<VehiculeModel> _lstVehiculeModel = new List<VehiculeModel>();
            foreach (Vehicule _vc in clsVehicules)
            {
                string _tTypeVehicule = "";
                foreach (TypeVehicule _tvc in lstTypeVehicule)
                {
                    if (_tvc.Id == _vc.IdTypeVehicule)
                    {
                        _tTypeVehicule = _tvc.NomTypeVehicule;
                    }
                }
                _lstVehiculeModel.Add(new VehiculeModel(
                    _vc.Id
                    , _vc.Nom
                    , _vc.Kilometrage
                    , _tTypeVehicule
                    , _vc.NbPlace
                    , _vc.estDisponible == 1 ? "Oui" : "Non"
                    ));
            }
            lstVehicules.ItemsSource = _lstVehiculeModel;
        }

        private void LstVehicules_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            VehiculeModel item = e.SelectedItem as VehiculeModel;
            Vehicule _vcSelected = new Vehicule();
            foreach (Vehicule _vc in clsVehicules)
            {
                if (_vc.Id == item.IdVehicule)
                {
                    _vcSelected = _vc;
                }
            }
            var ModifVehicule = new ModifVehicule(_vcSelected, lstTypeVehicule);
            ModifVehicule.RefreshListItems += ModifReservation_RefreshListItems;

            Navigation.PushAsync(ModifVehicule);
        }

        private void ModifReservation_RefreshListItems(object sender, EventArgs e)
        {
            SetListItems(true);
        }

        private void BtnAddVehicule_Clicked(object sender, EventArgs e)
        {
            var AddVehicule = new CreerVehicule( lstTypeVehicule);
            AddVehicule.RefreshListItems += ModifReservation_RefreshListItems;

            Navigation.PushAsync(AddVehicule);
        }
    }
}