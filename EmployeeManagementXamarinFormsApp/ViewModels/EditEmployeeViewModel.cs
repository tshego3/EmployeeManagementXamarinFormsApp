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

        public EmployeeBindingModel employeeBindingModel { get; set; }

        public ICommand PutEmployeeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = Settings.AccessToken;
                    await _apiServices.PutEmployeeAsync(employeeBindingModel, accesstoken);
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
                    await _apiServices.DeleteEmployeeAsync(employeeBindingModel.EmployeeID, accesstoken);
                });
            }
        }
    }
}
