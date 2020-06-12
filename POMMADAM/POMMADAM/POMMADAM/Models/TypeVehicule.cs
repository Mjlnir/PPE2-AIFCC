using System;
using System.Collections.Generic;
using System.Text;

namespace POMMADAM.Models
{
    public class TypeVehicule
    {
        public int Id { get; set; }
        public string NomTypeVehicule { get; set; }

        public TypeVehicule(int Id, string NomTypeVehicule)
        {
            this.Id = Id;
            this.NomTypeVehicule = NomTypeVehicule;
        }
    }
}
