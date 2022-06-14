using HydrationReminderApp.Views;
using Xamarin.Forms;

namespace HydrationReminderApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));

        }

    }
}
