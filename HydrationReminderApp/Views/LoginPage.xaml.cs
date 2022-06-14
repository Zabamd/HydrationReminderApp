﻿using HydrationReminderApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HydrationReminderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        public  void displayError(string error)
        {
            LoginErrorMessage.Text = error;
        }
    }
}