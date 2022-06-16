using Xamarin.Forms;
using Xamarin.Essentials;
using System;
using HydrationReminderApp.Models;
using HydrationReminderApp.Services;
using HydrationReminderApp.ViewModels;
using System.ComponentModel;
using HydrationReminderApp.Views;

namespace HydrationReminderApp.ViewModels
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command GridButtonPushed { get; } 
        public Command CustomButtonPushed { get; }

        public MainPageViewModel()
        {
            GridButtonPushed = new Command(OnGridButtonPushed);
            CustomButtonPushed = new Command(OnCustomButtonPushed);
        }
        public double ExpectedWaterAmount { get; set; } = ISessionContext.Water.ExpectedAmount;

        public double WaterAmount { get; set; } = ISessionContext.Water.Amount;
        public string WaterIntakeLabel
        {
            get
            {
                return String.Format("{0:F2} / {1:F2}", WaterAmount, ExpectedWaterAmount);
            }
        }

        private void OnGridButtonPushed(object obj)
        {
            ImageButton btn = (ImageButton)obj;
            switch (btn.AutomationId)
            {
                case "50":
                    WaterAmount += 50;
                    break;
                case "100":
                    WaterAmount += 100;
                    break;
                case "150":
                    WaterAmount += 150;
                    break;
                case "200":
                    WaterAmount += 200;
                    break;
                case "250":
                    WaterAmount += 250;
                    break;
            }
        }
        private void OnCustomButtonPushed(object obj)
        {
            WaterAmount += Double.Parse(ISessionContext.CustomAmount);
        }



    }
}