
using HydrationReminderApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HydrationReminderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
            this.BindingContext = new HistoryViewModel();
        }
    }
}