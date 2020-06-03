using System;
using System.Collections.Generic;
using System.Text;

namespace POMMADAM.ViewsModels
{
    class ReservationModel
    {
        public int IdReservation { get; set; }
        public string NomVehicule { get; set; }
        public string NomUtilisateur { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public bool isEnable { get; set; }

        public ReservationModel(int IdReservation, string NomVehicule, string NomUtilsateur, DateTime DateDebut, DateTime DateFin, bool ButtonEnable)
        {
            this.IdReservation = IdReservation;
            this.NomVehicule = NomVehicule;
            this.NomUtilisateur = NomUtilsateur;
            this.DateDebut = DateDebut;
            this.DateFin = DateFin;
            this.isEnable = ButtonEnable;
        }
    }
}
