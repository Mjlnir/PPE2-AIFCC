using Newtonsoft.Json.Linq;
using POMMADAM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POMMADAM.Controllers
{
    class UserController
    {
        /// <summary>
        /// Récupère les liste des utilisateurs.
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsers()
        {
            string _sCon = string.Format("{0}/{1}getUsers", Constants.API, Constants.API_UserController);
            JObject _jsonContent = new JObject();

            Task<List<User>> _tLstUsers = Task.Run(() => App.NetworkHelper.PostResponse<List<User>>(_sCon, _jsonContent));
            _tLstUsers.Wait();
            List<User> _lstUsers = _tLstUsers.Result;
            _tLstUsers.Dispose();
            return _lstUsers;
        }

        /// <summary>
        /// Permet de récupérer le nom de l'utilisateur via son id avec la liste des utlisateurs fournit en paramètre.
        /// </summary>
        /// <param name="_lstUsers"></param>
        /// <param name="_iId"></param>
        /// <returns></returns>
        public string GetNomUser(List<User> _lstUsers, int _iId)
        {
            string _sNomUser = "";
            foreach (User user in _lstUsers)
            {
                if (user.Id == _iId)
                {
                    _sNomUser = user.Nom + " " + user.Prenom;
                }
            }
            return _sNomUser;
        }
        /// <summary>
        /// Permet de créer un utilisateur.
        /// </summary>
        /// <param name="nomUser"></param>
        /// <param name="prenomUser"></param>
        /// <param name="mailUser"></param>
        /// <param name="TelUser"></param>
        /// <param name="LoginUser"></param>
        /// <param name="pwdUser"></param>
        /// <param name="idTypeUser"></param>
        /// <returns></returns>
        public object AddUser(string nomUser, string prenomUser, string mailUser, string TelUser, string LoginUser, string pwdUser, int idTypeUser)
        {
            string _sCon = string.Format("{0}/{1}addUser", Constants.API, Constants.API_UserController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("nomUser", nomUser);
            _jsonContent.Add("prenomUser", prenomUser);
            _jsonContent.Add("mailUser", mailUser);
            _jsonContent.Add("telUser", TelUser);
            _jsonContent.Add("loginUser", LoginUser);
            _jsonContent.Add("pwdUser", pwdUser);
            _jsonContent.Add("idTypeUser", idTypeUser);

            Task<object> _tLstReservations = Task.Run(() => App.NetworkHelper.PostResponse<object>(_sCon, _jsonContent));
            _tLstReservations.Wait();
            object _objResult = _tLstReservations.Result;
            _tLstReservations.Dispose();
            return _objResult;
        }
        /// <summary>
        /// Permet de modifier un utilisateur.
        /// </summary>
        /// <param name="nomUser"></param>
        /// <param name="prenomUser"></param>
        /// <param name="mailUser"></param>
        /// <param name="TelUser"></param>
        /// <param name="LoginUser"></param>
        /// <param name="pwdUser"></param>
        /// <param name="idTypeUser"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        public object UpdUser(string nomUser, string prenomUser, string mailUser, string TelUser, string LoginUser, string pwdUser, int idTypeUser, int idUser)
        {
            string _sCon = string.Format("{0}/{1}updUser", Constants.API, Constants.API_UserController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("nomUser", nomUser);
            _jsonContent.Add("prenomUser", prenomUser);
            _jsonContent.Add("mailUser", mailUser);
            _jsonContent.Add("telUser", TelUser);
            _jsonContent.Add("loginUser", LoginUser);
            _jsonContent.Add("pwdUser", pwdUser);
            _jsonContent.Add("idTypeUser", idTypeUser);
            _jsonContent.Add("idUser", idUser);

            Task<object> _tLstReservations = Task.Run(() => App.NetworkHelper.PostResponse<object>(_sCon, _jsonContent));
            _tLstReservations.Wait();
            object _objResult = _tLstReservations.Result;
            _tLstReservations.Dispose();
            return _objResult;
        }
        /// <summary>
        /// Permet de supprimer un utilisateur.
        /// </summary>
        /// <param name="_iIdUser"></param>
        public void DeleteUser(int _iIdUser)
        {
            string _sCon = string.Format("{0}/{1}delUser", Constants.API, Constants.API_UserController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("idUser", _iIdUser);

            Task<string> _tSuccessMessage = Task.Run(() => App.NetworkHelper.PostResponse<string>(_sCon, _jsonContent));
            _tSuccessMessage.Wait();
            string _tMessage = _tSuccessMessage.Result;
            _tSuccessMessage.Dispose();
        }
    }
}
