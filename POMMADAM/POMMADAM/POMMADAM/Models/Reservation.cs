using System;
using System.Collections.Generic;
using System.Text;

namespace POMMADAM.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime JourReservation { get; set; }
        public int IdUtilisateur { get; set; }
        public string NomUtilisateur { get; set; }
        public string PrenomUtilisateur { get; set; }
        public int IdVehicule { get; set; }
        public string NomVehicule { get; set; }
        public DateTime HeureFin { get; set; }

        public Reservation(){}
        public Reservation(int Id
            , DateTime JourReservation
            , int IdUtilisateur
            , string NomUtilisateur
            , string PrenomUtilisateur
            , int IdVehicule
            , DateTime HeureFin)
        {
            this.Id = Id;
            this.JourReservation = JourReservation;
            this.IdUtilisateur = IdUtilisateur;
            this.NomUtilisateur = NomUtilisateur;
            this.PrenomUtilisateur = PrenomUtilisateur;
            this.IdVehicule = IdVehicule;
            this.HeureFin = HeureFin;
        }
    }
}
