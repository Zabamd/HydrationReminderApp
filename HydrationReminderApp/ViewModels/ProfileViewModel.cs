
using Xamarin.Forms;

namespace HydrationReminderApp.ViewModels
{
    public class ProfileViewModel : ContentView
    {
        public ProfileViewModel()
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