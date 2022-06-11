using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HydrationReminderApp.ViewModels
{
    public class SIgnUpViewModelcs : ContentView
    {
        public SIgnUpViewModelcs()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin.Forms!" }
                }
            };
        }
    }
}