using System;
using System.Collections.Generic;
using System.Text;

namespace POMMADAM.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public string Login { get; set; }
        public string Mdp { get; set; }
        public int Type { get; set; }

        public User() { }
        public User(int Id, string Nom, string Prenom, string Mail, string Telephone, string Login, string Mdp, int Type)
        {
            this.Id = Id;
            this.Nom = Nom;
            this.Mail = Mail;
            this.Telephone = Telephone;
            this.Login = Login;
            this.Mdp = Mdp;
            this.Type = Type;
        }

        public bool CheckInfo()
        {
            if (!string.IsNullOrEmpty(this.Login) && !string.IsNullOrEmpty(this.Mdp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
