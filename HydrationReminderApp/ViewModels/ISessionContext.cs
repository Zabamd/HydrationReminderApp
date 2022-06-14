using HydrationReminderApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HydrationReminderApp.ViewModels
{
    public interface ISessionContext : INotifyPropertyChanged
    {
        Profile Profile { get; set; }
    }
}
