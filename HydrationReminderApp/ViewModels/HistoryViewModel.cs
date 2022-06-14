
using Xamarin.Forms;

namespace HydrationReminderApp.ViewModels
{
    public class HistoryViewModel : ContentView
    {
        public HistoryViewModel()
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