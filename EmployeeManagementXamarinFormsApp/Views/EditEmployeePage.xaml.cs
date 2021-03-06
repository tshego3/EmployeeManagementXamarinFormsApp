using EmployeeManagementXamarinFormsApp.Models;
using EmployeeManagementXamarinFormsApp.ViewModels;
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
    public partial class EditEmployeePage : ContentPage
    {
        public EditEmployeePage(EmployeeBindingModel employeeBindingModel)
        {
            //var editEmployeeViewModel = new EditEmployeeViewModel();
            //editEmployeeViewModel.Employee = employeeBindingModel;
            //BindingContext = editEmployeeViewModel;

            InitializeComponent();

            var editEmployeeViewModel = new EditEmployeeViewModel();
            editEmployeeViewModel.Employee = employeeBindingModel;
            BindingContext = editEmployeeViewModel;
        }
    }
}