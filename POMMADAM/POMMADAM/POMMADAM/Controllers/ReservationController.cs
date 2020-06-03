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

        public List<Reservation> GetReservationsByDate(DateTime _dtJourReservation, DateTime _dtHeureFin, int _iIdVehicule)
        {
            string _sCon = string.Format("{0}/{1}getReservationsByDate", Constants.API, Constants.API_ReservationController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("jourReservation", App.TimeHelper.toTimeSpan(_dtJourReservation));
            _jsonContent.Add("heureFin", App.TimeHelper.toTimeSpan(_dtHeureFin));
            _jsonContent.Add("idVehicule", _iIdVehicule + 1);

            Task<List<Reservation>> _tLstReservations = Task.Run(() => App.NetworkHelper.PostResponseWithDate<List<Reservation>>(_sCon, _jsonContent));
            _tLstReservations.Wait();
            List<Reservation> _lstReservations = _tLstReservations.Result;
            _tLstReservations.Dispose();
            return _lstReservations;
        }

        public List<Vehicule> GetVehiculesByDate(DateTime _dtJourReservation, DateTime _dtHeureFin)
        {
            string _sCon = string.Format("{0}/{1}getVehiculesByDate", Constants.API, Constants.API_ReservationController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("jourReservation", App.TimeHelper.toTimeSpan(_dtJourReservation));
            _jsonContent.Add("heureFin", App.TimeHelper.toTimeSpan(_dtHeureFin));

            Task<List<Vehicule>> _tLstReservations = Task.Run(() => App.NetworkHelper.PostResponse<List<Vehicule>>(_sCon, _jsonContent));
            _tLstReservations.Wait();
            List<Vehicule> _lstVehicules = _tLstReservations.Result;
            _tLstReservations.Dispose();
            return _lstVehicules;
        }

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
