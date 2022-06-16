
using HydrationReminderApp.ViewModels;
using System;
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
        private async void GridButtonClicked(object sender, EventArgs e)
        {
            var btn = (ImageButton)sender;
            await btn.ScaleTo(0.80, 100);
            await btn.FadeTo(0.75, 100);

            //For custom button
            if (btn.AutomationId == "400")
            {
                ISessionContext.CustomAmount = await DisplayPromptAsync("Custom amount", "Insert custom amount in ml", initialValue: "", maxLength: 4, keyboard: Keyboard.Numeric);
            }

            await btn.ScaleTo(1, 100);
            await btn.FadeTo(1, 100);

           

        }
    
    }
}