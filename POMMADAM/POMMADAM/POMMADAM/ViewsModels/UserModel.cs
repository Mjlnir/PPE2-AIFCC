using System;
using System.Collections.Generic;
using System.Text;

namespace POMMADAM.ViewsModels
{
    class UserModel
    {
        public int Id{ get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string TypeUtilisateur { get; set; }

        public UserModel(int Id,string Nom,string Prenom,string Telephone,string Login,string Password,string TypeUtilisateur)
        {
            this.Id = Id;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.Telephone = Telephone;
            this.Login = Login;
            this.Password = Password;
            this.TypeUtilisateur = TypeUtilisateur;
        }
    }
}
