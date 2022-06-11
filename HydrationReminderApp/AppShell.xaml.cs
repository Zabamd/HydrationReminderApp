using HydrationReminderApp.ViewModels;
using HydrationReminderApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HydrationReminderApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            /*
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            */
        }

    }
}
