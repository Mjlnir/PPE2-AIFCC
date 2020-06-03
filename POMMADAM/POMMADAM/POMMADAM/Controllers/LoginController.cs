using Newtonsoft.Json.Linq;
using POMMADAM.Models;
using SaisieProdSite.Helpers;
using System.Threading.Tasks;

namespace POMMADAM.Controllers
{
    public class LoginController
    {
        public User Login(string _sLogin, string _sMdp)
        {
            string _sCon = string.Format("{0}/{1}login",Constants.API,Constants.API_LoginController);
            JObject _jsonContent = new JObject();
            _jsonContent.Add("username", _sLogin);
            _jsonContent.Add("password", _sMdp);

            Task<User> _tUser = Task.Run(() => App.NetworkHelper.PostResponse<User>(_sCon, _jsonContent));
            _tUser.Wait();
            User _user = _tUser.Result;
            return _user;
        }
    }
}
