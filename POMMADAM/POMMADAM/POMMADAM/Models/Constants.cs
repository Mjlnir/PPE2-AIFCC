using System;
using System.Collections.Generic;
using System.Text;

namespace POMMADAM.Models
{
    /// <summary>
    /// Permet de stocker des variables tels que les différents liens vers l'API. Accessible partout dans le code.
    /// </summary>
    public class Constants
    {
        //public static string API = "https://8bd0a67f22df.ngrok.io";
        public static string API = "https://sio2020.aden.school/~ftrudelle";
        public static string API_LoginController = "PPE2-AIFCC/API/controllers/loginController.php?action=";
        public static string API_ReservationController = "PPE2-AIFCC/API/controllers/reservationController.php?action=";
        public static string API_TypeVehiculeController = "PPE2-AIFCC/API/controllers/typeVehiculeController.php?action=";
        public static string API_VehiculeController = "PPE2-AIFCC/API/controllers/vehiculeController.php?action=";
        public static string API_TypeUtilisateurController = "PPE2-AIFCC/API/controllers/typeUtilisateurController.php?action=";
        public static string API_UserController = "PPE2-AIFCC/API/controllers/userController.php?action=";
    }
}
