using POMMADAM.Helpers;
using POMMADAM.Models;
using POMMADAM.Views;
using SaisieProdSite.Helpers;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace POMMADAM
{
    public partial class App : Application
    {
        static NetworkHelper networkH;
        static TimeHelper timeH;
        public User loggedUser;
        public Dictionary<string, object> Properties = new Dictionary<string, object>();
        public App()
        {
            InitializeComponent();

            isLoggedIn = false;
            PresentMainPage();
        }

        public void PresentMainPage()
        {
            MainPage = !isLoggedIn ? (Page)new LoginPage() : new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static bool isLoggedIn
        {
            get;
            set;
        }

        public static NetworkHelper NetworkHelper
        {
            get
            {
                if (networkH == null)
                {
                    networkH = new NetworkHelper();
                }
                return networkH;
            }
        }
        public static TimeHelper TimeHelper
        {
            get
            {
                if (timeH == null)
                {
                    timeH = new TimeHelper();
                }
                return timeH;
            }
        }
    }
}
