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
	public partial class ModifUser : ContentPage
	{
        List<TypeUtilisateur> lstTypeUsers;
        User uSelected;
        public event EventHandler RefreshListItems;
        public ModifUser (User _user, List<TypeUtilisateur> _lstTypeUtilisateurs)
		{
			InitializeComponent ();
            lstTypeUsers = _lstTypeUtilisateurs;
            uSelected = _user;
            txtNom.Text = uSelected.Nom;
            txtPrenom.Text = uSelected.Prenom;
            txtMail.Text = uSelected.Mail;
            txtTel.Text = uSelected.Telephone;
            txtPwd.Text = uSelected.Mdp;
            txtCPwd.Text = uSelected.Mdp;
            pckTypeU.ItemsSource = lstTypeUsers;
            pckTypeU.SelectedIndex = uSelected.Type - 1;
            Title = "Modifcation de l'utilisateur n°" + uSelected.Id;
        }

        private void ConfirmerModif(object sender, System.EventArgs e)
        {
            UserController _clsUserController = new UserController();
            int _iTypeIdUser = 0;
            if (pckTypeU.SelectedIndex == -1)
            {
                DisplayAlert("Erreur", "Veuillez sélectionner un type de véhicule.", "Ok");
                return;
            }
            foreach (TypeUtilisateur _u in lstTypeUsers)
            {
                if (((TypeUtilisateur)pckTypeU.SelectedItem).NomTypeUtilisateur == _u.NomTypeUtilisateur)
                {
                    _iTypeIdUser = _u.Id;
                }
            }
            if (string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtPrenom.Text) || string.IsNullOrEmpty(txtMail.Text) || string.IsNullOrEmpty(txtTel.Text) || string.IsNullOrEmpty(txtPwd.Text) || string.IsNullOrEmpty(txtCPwd.Text))
            {
                DisplayAlert("Erreur", "Veuillez vérifier les champs Nom, Prénom, Mail, Téléphone, Mot de passer et confirmation de mot de passe ne doivent pas êtres nuls.", "Ok");
                return;
            }
            if (txtPwd.Text != txtCPwd.Text)
            {
                DisplayAlert("Erreur", "Les mots de passes ne correspondent pas. Veuillez ressaisir les mots de passes.", "Ok");
                return;
            }
            string _tLogin = "";
            if (txtNom.Text.Length <= 7)
            {
                _tLogin = txtPrenom.Text[0] + txtNom.Text;
            }
            else
            {
                _tLogin = txtPrenom.Text[0] + txtNom.Text.Substring(0, 7);
            }  
            object _objReturn = _clsUserController.UpdUser(
                txtNom.Text
                , txtPrenom.Text
                , txtMail.Text
                , txtTel.Text
                , _tLogin
                , txtPwd.Text
                , _iTypeIdUser
                , uSelected.Id);
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
            UserController _clsUserController = new UserController();
            _clsUserController.DeleteUser(uSelected.Id);
            if (RefreshListItems != null)
            {
                RefreshListItems(this, EventArgs.Empty);
            }
            Navigation.PopAsync();
        }
    }
}