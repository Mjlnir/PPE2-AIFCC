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
    }
}
