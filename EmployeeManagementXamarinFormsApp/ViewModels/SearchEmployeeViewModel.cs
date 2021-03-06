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
    public class SearchEmployeeViewModel : INotifyPropertyChanged
    {
        ApiServices _apiServices = new ApiServices();
        private List<EmployeeBindingModel> _employees;

        public string Keyword { get; set; }

        public List<EmployeeBindingModel> Employees
        {
            get { return _employees; }
            set
            {
                _employees = value;
                OnPropertyChanged();
            }
        }

        public ICommand SearchEmployeesCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var accesstoken = Settings.AccessToken;
                    Employees = await _apiServices.SearchEmployeesAsync(Keyword, accesstoken);
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
