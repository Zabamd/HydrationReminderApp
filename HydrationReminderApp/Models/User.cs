using System;
using System.Collections.Generic;
using System.Text;

namespace HydrationReminderApp.Models
{
    internal class User
    { 
        public User(string username, string password )
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }

    }
}
