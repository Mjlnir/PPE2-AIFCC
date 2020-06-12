using Newtonsoft.Json.Linq;
using POMMADAM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POMMADAM.Controllers
{
    class TypeVehiculeController
    {
        /// <summary>
        /// Récupère la liste des types véhicule.
        /// </summary>
        /// <returns></returns>
        public List<TypeVehicule> GetTypesVehicules()
        {
            string _sCon = string.Format("{0}/{1}getTypesVehicules", Constants.API, Constants.API_TypeVehiculeController);
            JObject _jsonContent = new JObject();

            Task<List<TypeVehicule>> _tTypeVehicule = Task.Run(() => App.NetworkHelper.PostResponse<List<TypeVehicule>>(_sCon, _jsonContent));
            _tTypeVehicule.Wait();
            List<TypeVehicule> _lstTypeVehicule = _tTypeVehicule.Result;
            _tTypeVehicule.Dispose();
            return _lstTypeVehicule;
        }
    }
}
