using EmployeeManagementXamarinFormsApp.Helpers;
using EmployeeManagementXamarinFormsApp.Models;
using EmployeeManagementXamarinFormsApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmployeeManagementXamarinFormsApp.ViewModels
{
    public class EmployeesViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();

        //public string AccessToken { get; set; }
        public List<EmployeeBindingModel> Employees
        {
            get { return Employees; }
            set
            {
                Employees = value;
                OnPropertyChanged();
            }
        }
        public ICommand GetEmployeesCommand
        {
            get
            {
                return new Command(async () =>
                {
                    //Employees = await _apiServices.GetEmployeesAsync(AccessToken);
                    var accesstoken = Settings.AccessToken;
                    Employees = await _apiServices.GetEmployeesAsync(accesstoken);
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
