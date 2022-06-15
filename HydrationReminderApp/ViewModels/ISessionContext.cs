using System;
using System.Collections.Generic;
using System.Text;
using HydrationReminderApp.Models;
namespace HydrationReminderApp.ViewModels
{   
    /// <summary>
    /// Class Used to exchange Profile data between ViewModels
    /// </summary>
    public class ISessionContext
    {
        public static Profile Profile { get; set; }
    }
}
