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
    public partial class CreerUser : ContentPage
    {
        List<TypeUtilisateur> lstTypesUtilisateurs;
        public event EventHandler RefreshListItems;

        public CreerUser(List<TypeUtilisateur> _lstTypeUtilisateur)
        {
            InitializeComponent();
            lstTypesUtilisateurs = _lstTypeUtilisateur;
            pckTypeU.ItemsSource = lstTypesUtilisateurs;
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
            foreach (TypeUtilisateur _tu in lstTypesUtilisateurs)
            {
                if (((TypeUtilisateur)pckTypeU.SelectedItem).NomTypeUtilisateur == _tu.NomTypeUtilisateur)
                {
                    _iTypeIdUser = _tu.Id;
                }
            }
            if (string.IsNullOrEmpty(txtNom.Text) || string.IsNullOrEmpty(txtPrenom.Text) || string.IsNullOrEmpty(txtMail.Text) || string.IsNullOrEmpty(txtTel.Text))
            {
                DisplayAlert("Erreur", "Veuillez vérifier les champs, Nom, Prénom, Mail ou Tel. Ils ne doivent pas êtres nuls.", "Ok");
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
            object _objReturn = _clsUserController.AddUser(
                txtNom.Text
                , txtPrenom.Text
                , txtMail.Text
                , txtTel.Text
                , _tLogin
                , txtPwd.Text
                , _iTypeIdUser);
            if (!string.IsNullOrEmpty(_objReturn.ToString()) && RefreshListItems != null)
            {
                RefreshListItems(this, EventArgs.Empty);
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Erreur", "Un problème est survenue lors de l'ajout.", "Ok");
            }
        }

        private void AnnulerModif(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}