using System;
using System.Collections.Generic;
using System.Text;

namespace POMMADAM.Models
{
    public class TypeUtilisateur
    {
        public int Id { get; set; }
        public string NomTypeUtilisateur { get; set; }

        public TypeUtilisateur(int Id, string NomTypeUtilisateur)
        {
            this.Id = Id;
            this.NomTypeUtilisateur = NomTypeUtilisateur;
        }
    }
}
