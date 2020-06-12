using System;
using System.Collections.Generic;
using System.Text;

namespace POMMADAM.ViewsModels
{
    class VehiculeModel
    {
        public int IdVehicule { get; set; }
        public string NomVehicule { get; set; }
        public int KilometrageVehicule { get; set; }
        public int? NbPlace { get; set; }
        public string TypeVehicule { get; set; }
        public string EstDispo { get; set; }

        public VehiculeModel(int IdVehicule, string NomVehicule, int KilometrageVehicule, string TypeVehicule, int? NbPlace, string EstDispo)
        {
            this.IdVehicule = IdVehicule;
            this.NomVehicule = NomVehicule;
            this.KilometrageVehicule = KilometrageVehicule;
            this.TypeVehicule = TypeVehicule;
            this.NbPlace = NbPlace;
            this.EstDispo = EstDispo;
        }
    }
}
