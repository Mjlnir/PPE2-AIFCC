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
        /// <summary>
        /// Récupère la liste des véhicules.
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Permet de récupérer le nom du véhicule via son id avec la liste des véhicules fournit en paramètre.
        /// </summary>
        /// <param name="_lstVehicules"></param>
        /// <param name="_iId"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Permet de récupérer une liste de véhicule qui ne sont pas déjà réservé dans la tranche horaire défini par l'utilisateur.
        /// </summary>
        /// <param name="_dtJourReservation"></param>
        /// <param name="_dtHeureFin"></param>
        /// <returns></returns>
        public List<Vehicule> GetVehiculesByDate(DateTime _dtJourReservation, DateTime _dtHeureFin)
        {
            string _sCon = string.Format("{0}/{1}getVehiculesByDate", Constants.API, Constants.API_VehiculeController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("jourReservation", App.TimeHelper.toTimeSpan(_dtJourReservation));
            _jsonContent.Add("heureFin", App.TimeHelper.toTimeSpan(_dtHeureFin));

            Task<List<Vehicule>> _tLstReservations = Task.Run(() => App.NetworkHelper.PostResponse<List<Vehicule>>(_sCon, _jsonContent));
            _tLstReservations.Wait();
            List<Vehicule> _lstVehicules = _tLstReservations.Result;
            _tLstReservations.Dispose();
            return _lstVehicules;
        }
        /// <summary>
        /// Permet de créer un véhicule
        /// </summary>
        /// <param name="_tNomVehicule"></param>
        /// <param name="_iKilometrage"></param>
        /// <param name="_iNbPlace"></param>
        /// <param name="_iEstDispo"></param>
        /// <param name="_iIdTypeVehicule"></param>
        /// <returns></returns>
        public object AddVehicule(string _tNomVehicule, int _iKilometrage, int _iNbPlace, int _iEstDispo, int _iIdTypeVehicule)
        {
            string _sCon = string.Format("{0}/{1}addVehicule", Constants.API, Constants.API_VehiculeController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("nomVehicule", _tNomVehicule);
            _jsonContent.Add("kilometrage", _iKilometrage);
            _jsonContent.Add("nbPlace", _iNbPlace);
            _jsonContent.Add("estDispo", _iEstDispo);
            _jsonContent.Add("idTypeVehicule", _iIdTypeVehicule);

            Task<object> _tLstReservations = Task.Run(() => App.NetworkHelper.PostResponse<object>(_sCon, _jsonContent));
            _tLstReservations.Wait();
            object _objResult = _tLstReservations.Result;
            _tLstReservations.Dispose();
            return _objResult;
        }
        /// <summary>
        /// Permet de modifier un véhicule
        /// </summary>
        /// <param name="_iIdVehicule"></param>
        /// <param name="_tNomVehicule"></param>
        /// <param name="_iKilometrage"></param>
        /// <param name="_iNbPlace"></param>
        /// <param name="_iEstDispo"></param>
        /// <param name="_iIdTypeVehicule"></param>
        /// <returns></returns>
        public object ModifVehicule(int _iIdVehicule, string _tNomVehicule, int _iKilometrage, int _iNbPlace, int _iEstDispo, int _iIdTypeVehicule)
        {
            string _sCon = string.Format("{0}/{1}updVehicule", Constants.API, Constants.API_VehiculeController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("idVehicule", _iIdVehicule);
            _jsonContent.Add("nomVehicule", _tNomVehicule);
            _jsonContent.Add("kilometrage", _iKilometrage);
            _jsonContent.Add("nbPlace", _iNbPlace);
            _jsonContent.Add("estDispo", _iEstDispo);
            _jsonContent.Add("idTypeVehicule", _iIdTypeVehicule);

            Task<object> _tLstReservations = Task.Run(() => App.NetworkHelper.PostResponse<object>(_sCon, _jsonContent));
            _tLstReservations.Wait();
            object _objResult = _tLstReservations.Result;
            _tLstReservations.Dispose();
            return _objResult;
        }
        /// <summary>
        /// Permet de supprimer un véhicule
        /// </summary>
        /// <param name="_iIdVehicule"></param>
        public void DeleteVehicule(int _iIdVehicule)
        {
            string _sCon = string.Format("{0}/{1}delVehicule", Constants.API, Constants.API_VehiculeController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("idVehicule", _iIdVehicule);

            Task<string> _tSuccessMessage = Task.Run(() => App.NetworkHelper.PostResponse<string>(_sCon, _jsonContent));
            _tSuccessMessage.Wait();
            string _tMessage = _tSuccessMessage.Result;
            _tSuccessMessage.Dispose();
        }
    }
}
