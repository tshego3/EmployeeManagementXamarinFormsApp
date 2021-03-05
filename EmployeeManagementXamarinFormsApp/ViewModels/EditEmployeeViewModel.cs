using EmployeeManagementXamarinFormsApp.Helpers;
using EmployeeManagementXamarinFormsApp.Models;
using EmployeeManagementXamarinFormsApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmployeeManagementXamarinFormsApp.ViewModels
{
    public class EditEmployeeViewModel
    {
        ApiServices _apiServices = new ApiServices();

        public EmployeeBindingModel Employee { get; set; } //***ALWAYS MAKE PROPERTIES NAME'S CAMEL CASE.***

        public ICommand PutEmployeeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = Settings.AccessToken;
                    await _apiServices.PutEmployeeAsync(Employee, Settings.AccessToken);
                });
            }
        }

        public ICommand DeleteEmployeeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = Settings.AccessToken;
                    await _apiServices.DeleteEmployeeAsync(Employee.EmployeeID, Settings.AccessToken);
                });
            }
        }
    }
}
