using HydrationReminderApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace HydrationReminderApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}