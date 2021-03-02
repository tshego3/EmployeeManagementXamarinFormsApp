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
    public class AddNewEmployeeViewModel
    {
        ApiServices _apiServices = new ApiServices();

        public string TbFirstName { get; set; }
        public string TbSurname { get; set; }
        public string TbTellNo { get; set; }
        public string TbEmail { get; set; }

        public ICommand AddEmployeeCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = Settings.AccessToken;
                    var employee = new EmployeeBindingModel
                    {
                        TbFirstName = TbFirstName,
                        TbSurname = TbSurname,
                        TbTellNo = TbTellNo,
                        TbEmail = TbEmail
                    };
                    await _apiServices.PostEmployeesAsync(employee,accesstoken);
                });
            }
        }
    }
}
