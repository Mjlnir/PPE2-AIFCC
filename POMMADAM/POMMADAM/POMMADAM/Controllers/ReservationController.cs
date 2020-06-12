using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using POMMADAM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POMMADAM.Controllers
{
    class ReservationController
    {
        /// <summary>
        /// Récupère tous les utilisateurs.
        /// </summary>
        /// <returns></returns>
        public List<Reservation>  GetReservations()
        {
            string _sCon = string.Format("{0}/{1}getReservations", Constants.API, Constants.API_ReservationController);
            JObject _jsonContent = new JObject();

            Task<List<Reservation>> _tLstReservations = Task.Run(() => App.NetworkHelper.PostResponseWithDate<List<Reservation>>(_sCon, _jsonContent));
            _tLstReservations.Wait();
            List<Reservation> _lstReservations = _tLstReservations.Result;
            _tLstReservations.Dispose();
            return _lstReservations;
        }
        /// <summary>
        /// Permet de récupérer les réservation qui sont entre les dates choisis par l'utilisateur. 
        /// Si la liste n'est pas vide, c'est qu'il doit changer de véhicule ou de date car une réservation à déjà été émise pour le véhicule et dates choisis.
        /// </summary>
        /// <param name="_dtJourReservation"></param>
        /// <param name="_dtHeureFin"></param>
        /// <param name="_iIdVehicule"></param>
        /// <returns></returns>
        public List<Reservation> GetReservationsByDate(DateTime _dtJourReservation, DateTime _dtHeureFin, int _iIdVehicule)
        {
            string _sCon = string.Format("{0}/{1}getReservationsByDate", Constants.API, Constants.API_ReservationController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("jourReservation", App.TimeHelper.toTimeSpan(_dtJourReservation));
            _jsonContent.Add("heureFin", App.TimeHelper.toTimeSpan(_dtHeureFin));
            _jsonContent.Add("idVehicule", _iIdVehicule);

            Task<List<Reservation>> _tLstReservations = Task.Run(() => App.NetworkHelper.PostResponseWithDate<List<Reservation>>(_sCon, _jsonContent));
            _tLstReservations.Wait();
            List<Reservation> _lstReservations = _tLstReservations.Result;
            _tLstReservations.Dispose();
            return _lstReservations;
        }

        /// <summary>
        /// Permet de réserver un véhicule.
        /// </summary>
        /// <param name="_iIdVehicule"></param>
        /// <param name="_dtJourReservation"></param>
        /// <param name="_dtHeureFin"></param>
        /// <param name="_iIdUtilisateur"></param>
        /// <returns></returns>
        public object Reserver(int _iIdVehicule, DateTime _dtJourReservation, DateTime _dtHeureFin, int _iIdUtilisateur)
        {
            string _sCon = string.Format("{0}/{1}addReservation", Constants.API, Constants.API_ReservationController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("idVehicule", _iIdVehicule);
            _jsonContent.Add("jourReservation", App.TimeHelper.toTimeSpan(_dtJourReservation));
            _jsonContent.Add("heureFin", App.TimeHelper.toTimeSpan(_dtHeureFin));
            _jsonContent.Add("idItuilisateur", _iIdUtilisateur);

            Task<object> _tLstReservations = Task.Run(() => App.NetworkHelper.PostResponse<object>(_sCon, _jsonContent));
            _tLstReservations.Wait();
            object _objResult = _tLstReservations.Result;
            _tLstReservations.Dispose();
            return _objResult;
        }

        /// <summary>
        /// Permet de moodifier une réservation.
        /// </summary>
        /// <param name="_iIdReservation"></param>
        /// <param name="_iIdVehicule"></param>
        /// <param name="_dtJourReservation"></param>
        /// <param name="_dtHeureFin"></param>
        /// <returns></returns>
        public object ModifReservation(int _iIdReservation, int _iIdVehicule, DateTime _dtJourReservation, DateTime _dtHeureFin)
        {
            string _sCon = string.Format("{0}/{1}updReservation", Constants.API, Constants.API_ReservationController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("idReservation", _iIdReservation);
            _jsonContent.Add("idVehicule", _iIdVehicule);
            _jsonContent.Add("jourReservation", App.TimeHelper.toTimeSpan(_dtJourReservation));
            _jsonContent.Add("heureFin", App.TimeHelper.toTimeSpan(_dtHeureFin));

            Task<object> _tLstReservations = Task.Run(() => App.NetworkHelper.PostResponse<object>(_sCon, _jsonContent));
            _tLstReservations.Wait();
            object _objResult = _tLstReservations.Result;
            _tLstReservations.Dispose();
            return _objResult;
        }
        /// <summary>
        /// Permet de supprimer un véhicule.
        /// </summary>
        /// <param name="_iIdReservation"></param>
        public void DeleteReservation(int _iIdReservation)
        {
            string _sCon = string.Format("{0}/{1}delReservation", Constants.API, Constants.API_ReservationController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("idReservation", _iIdReservation);

            Task<string> _tSuccessMessage = Task.Run(() => App.NetworkHelper.PostResponse<string>(_sCon, _jsonContent));
            _tSuccessMessage.Wait();
            string _tMessage  = _tSuccessMessage.Result;
            _tSuccessMessage.Dispose();
        }
    }
}
