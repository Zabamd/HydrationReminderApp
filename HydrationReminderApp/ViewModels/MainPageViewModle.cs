using HydrationReminderApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;
    
namespace HydrationReminderApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        Profile Profile;
        public MainPageViewModel(Profile profile)
        {
            this.Profile = profile;
        }

    }
}