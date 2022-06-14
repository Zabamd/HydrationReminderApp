
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HydrationReminderApp.ViewModels;

namespace HydrationReminderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        
        public ProfilePage()
        {
            InitializeComponent();
            this.BindingContext = new ProfileViewModel();
        }
    }
}