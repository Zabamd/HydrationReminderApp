using System;
using System.Collections.Generic;
using System.Text;

namespace HydrationReminderApp.Models
{
    internal class NewUser : User
    {
        public NewUser(string username, string password) : base(username, password)
        {
        }
    }
}
