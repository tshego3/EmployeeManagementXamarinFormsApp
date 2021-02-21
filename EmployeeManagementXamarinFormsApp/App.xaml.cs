using EmployeeManagementXamarinFormsApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeManagementXamarinFormsApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            MainPage = new RegisterPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
