
using HydrationReminderApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace HydrationReminderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();


        }
    }
}