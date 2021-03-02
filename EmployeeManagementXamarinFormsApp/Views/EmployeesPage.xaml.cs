﻿using System;
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
    }
}