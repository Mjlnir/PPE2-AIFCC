using POMMADAM.Controllers;
using POMMADAM.Models;
using POMMADAM.ViewsModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace POMMADAM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UtilisateurPage : ContentPage
	{
        UserController clsUserController = new UserController();
        List<TypeUtilisateur> lstTypeUtilisateur = ((App)App.Current).Properties["TypesUtilisateurs"] as List<TypeUtilisateur>;
        List<User> clsUsers = ((App)App.Current).Properties["Users"] as List<User>;
        User user = ((App)App.Current).Properties["LoggedUser"] as User;
        public UtilisateurPage ()
		{
			InitializeComponent ();

            if (user.Type < 3)
            {
                lblForLstUsers.IsVisible = true;
                lstUsers.IsVisible = true;
                lblDroit.IsVisible = false;
                btnAddUser.IsVisible = true;
                lstUsers.HasUnevenRows = true;
                SetListItems(false);
            }

        }
        public void SetListItems(bool _blRefresh)
        {
            if (_blRefresh)
            {
                clsUsers = clsUserController.GetUsers();
            }
            List<UserModel> _lstVehiculeModel = new List<UserModel>();
            foreach (User _u in clsUsers)
            {
                string _tTypeUtilisateur = "";
                foreach (TypeUtilisateur _tu in lstTypeUtilisateur)
                {
                    if (_tu.Id == _u.Type)
                    {
                        _tTypeUtilisateur = _tu.NomTypeUtilisateur;
                    }
                }
                _lstVehiculeModel.Add(new UserModel(
                    _u.Id
                    ,_u.Nom
                    , _u.Prenom
                    ,_u.Telephone
                    ,_u.Login
                    ,_u.Mdp
                    , _tTypeUtilisateur
                    ));
            }
            lstUsers.ItemsSource = _lstVehiculeModel;
        }
        private void BtnAddUser_Clicked(object sender, EventArgs e)
        {
            var AddUser = new CreerUser(lstTypeUtilisateur);
            AddUser.RefreshListItems += ModifReservation_RefreshListItems;

            Navigation.PushAsync(AddUser);
        }

        private void LstUsers_ItemTapped(object sender, SelectedItemChangedEventArgs e)
        {
            UserModel item = e.SelectedItem as UserModel;
            User _uSelected = new User();
            foreach (User _u in clsUsers)
            {
                if (_u.Id == item.Id)
                {
                    _uSelected = _u;
                }
            }
            var ModifVehicule = new ModifUser(_uSelected, lstTypeUtilisateur);
            ModifVehicule.RefreshListItems += ModifReservation_RefreshListItems;

            Navigation.PushAsync(ModifVehicule);
        }
        private void ModifReservation_RefreshListItems(object sender, EventArgs e)
        {
            SetListItems(true);
        }

        private void BtnDeco_Clicked(object sender, EventArgs e)
        {
            App.isLoggedIn = false;
            ((App)App.Current).PresentMainPage();
        }
    }
}