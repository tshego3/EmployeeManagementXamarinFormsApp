using EmployeeManagementXamarinFormsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeManagementXamarinFormsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeesPage : ContentPage
    {
        public EmployeesPage()
        {
            InitializeComponent();
        }

        private async void GoToAddNewEmployeePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewEmployeePage());
        }

        private async void GoToEditEmployeePage_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var employeeBindingModel = e.Item as EmployeeBindingModel;
            await Navigation.PushAsync(new EditEmployeePage(employeeBindingModel));
        }

        private async void Logout_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void GoToSearchEmployeePage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchEmployeePage());
        }
    }
}