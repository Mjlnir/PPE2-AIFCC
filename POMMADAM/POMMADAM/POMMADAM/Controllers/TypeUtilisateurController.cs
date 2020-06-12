using Newtonsoft.Json.Linq;
using POMMADAM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace POMMADAM.Controllers
{
    class TypeUtilisateurController
    {
        /// <summary>
        /// Récupère la liste des Types Utilisateur.
        /// </summary>
        /// <returns></returns>
        public List<TypeUtilisateur> GetTypesUtilisateurs()
        {
            string _sCon = string.Format("{0}/{1}getTypesUtilisateurs", Constants.API, Constants.API_TypeUtilisateurController);
            JObject _jsonContent = new JObject();

            Task<List<TypeUtilisateur>> _tTypeUtilisateur = Task.Run(() => App.NetworkHelper.PostResponse<List<TypeUtilisateur>>(_sCon, _jsonContent));
            _tTypeUtilisateur.Wait();
            List<TypeUtilisateur> _lstTypeUtilisateur = _tTypeUtilisateur.Result;
            _tTypeUtilisateur.Dispose();
            return _lstTypeUtilisateur;
        }
    }
}
