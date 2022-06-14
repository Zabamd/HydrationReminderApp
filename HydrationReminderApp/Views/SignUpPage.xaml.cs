using HydrationReminderApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HydrationReminderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
      
        public SignUpPage()
        {
            InitializeComponent();
            this.BindingContext = new SignUpViewModel();

        }
        
    }
}