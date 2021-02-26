using EmployeeManagementXamarinFormsApp.Helpers;
using EmployeeManagementXamarinFormsApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmployeeManagementXamarinFormsApp.ViewModels
{
    public class RegisterViewModel
    {
        ApiServices _apiServices = new ApiServices();

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var IsSuccess = await _apiServices.RegisterAsync(Email, Password, ConfirmPassword);

                    Settings.Username = Email;
                    Settings.Password = Password;

                    if (IsSuccess)
                    {
                        Message = "Registerd Successfully!";
                    }
                    else
                    {
                        Message = "Please try again later.";
                    }
                });
            }
        }
    }
}
