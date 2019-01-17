using Microsoft.WindowsAzure.MobileServices;
using PersonalExpenses.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PersonalExpenses.Resources;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Push;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PersonalExpenses
{
    public partial class App : Application
    {
        public static string DatabasePath;
        public static MobileServiceClient mobileServiceClient = new MobileServiceClient("https://persnalexpense0.azurewebsites.net");

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public App(string databasePath)
        {
            InitializeComponent();

            //AppResources.Culture = new System.Globalization.CultureInfo("es");

            MainPage = new NavigationPage(new MainPage());

            DatabasePath = databasePath;
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=09e469fd-6d7a-4f0f-891e-50e50eccd816;ios=c01289e6-3168-4d46-a6c1-9e76c1718942", typeof(Analytics), typeof(Push), typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
