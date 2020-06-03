using Newtonsoft.Json.Linq;
using POMMADAM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POMMADAM.Controllers
{
    class VehiculeController
    {
        public List<Vehicule> GetVehicules()
        {
            string _sCon = string.Format("{0}/{1}getVehicules", Constants.API, Constants.API_VehiculeController);
            JObject _jsonContent = new JObject();

            Task<List<Vehicule>> _tLstVehicules = Task.Run(() => App.NetworkHelper.PostResponse<List<Vehicule>>(_sCon, _jsonContent));
            _tLstVehicules.Wait();
            List<Vehicule> _lstVehicules = _tLstVehicules.Result;
            _tLstVehicules.Dispose();
            return _lstVehicules;
        }

        public string GetNomVehicule(List<Vehicule> _lstVehicules, int _iId)
        {
            string _sNomVehicule = "";
            foreach (Vehicule vehicule in _lstVehicules)
            {
                if (vehicule.Id == _iId)
                {
                    _sNomVehicule = vehicule.Nom;
                }
            }
            return _sNomVehicule;
        }
    }
}
