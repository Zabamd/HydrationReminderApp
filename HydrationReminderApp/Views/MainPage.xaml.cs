
using HydrationReminderApp.Models;
using HydrationReminderApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace HydrationReminderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        bool runTimer;
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();
            //Timer for UI updates
            Device.StartTimer(TimeSpan.FromMilliseconds(200), () =>
            {
                //Add +1 until as large as amount scaled
                //if radius == scaled down amount stop adding
                runTimer = true;
                double scaledAmout = ScaleValues(ISessionContext.WaterIntake);
                if (scaledAmout != Double.Parse("0"))
                {
                    while (scaledAmout != (InnerCircle.Width) && scaledAmout != (InnerCircle.Height))
                    {
                        InnerCircle.HeightRequest += 1;
                        InnerCircle.WidthRequest += 1;
                    }
                }
                else
                {
                    InnerCircle.WidthRequest = 0;
                    InnerCircle.HeightRequest = 0;
                }
                return runTimer;
            });


        }
        private async void GridButtonClicked(object sender, EventArgs e)
        {
            var btn = (ImageButton)sender;
            await btn.ScaleTo(0.80, 100);
            await btn.FadeTo(0.75, 100);

            //Adding custom amount through Display Promp
            if (btn.AutomationId == "400")
            {
                var customAmount = await DisplayPromptAsync("Custom amount", "Insert custom amount in ml", initialValue: "", maxLength: 4, keyboard: Keyboard.Numeric);
                ISessionContext.WaterIntake.Amount += Double.Parse(customAmount);
            }

            await btn.ScaleTo(1, 100);
            await btn.FadeTo(1, 100);
        }

        private double ScaleValues(WaterIntake waterIntake)
        {
            return (waterIntake.Amount * 250) / (waterIntake.ExpectedAmount);
        }

    }

}