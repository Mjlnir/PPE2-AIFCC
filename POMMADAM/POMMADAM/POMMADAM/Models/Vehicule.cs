using System;
using System.Collections.Generic;
using System.Text;

namespace POMMADAM.Models
{
    public class Vehicule
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int estDisponible { get; set; }
        public int Kilometrage { get; set; }
        public int IdTypeVehicule { get; set; }
        public int? NbPlace { get; set; }

        public Vehicule() { }
        public Vehicule(int Id
            , string NomVehicule
            , int estDisponible
            , int KilometrageVehicule
            , int IdTypeVehicule
            , int? NbPlaceVehicule)
        {
            this.Id = Id;
            this.Nom = NomVehicule;
            this.estDisponible = estDisponible;
            this.Kilometrage = KilometrageVehicule;
            this.IdTypeVehicule = IdTypeVehicule;
            this.NbPlace = NbPlace;
        }
    }
}
