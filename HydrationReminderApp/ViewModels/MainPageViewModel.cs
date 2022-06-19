using System.ComponentModel;
using Xamarin.Forms;

namespace HydrationReminderApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Command GridButtonPushed { get; }
        public Command CustomButtonPushed { get; }

        public MainPageViewModel()
        {
            GridButtonPushed = new Command(OnGridButtonPushed);
        }
        private double expectedWaterAmount = ISessionContext.WaterIntake.ExpectedAmount;
        public double ExpectedWaterAmount
        {
            get { return expectedWaterAmount; }
            set
            {
                expectedWaterAmount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ExpectedWaterAmount"));
            }
        }

        private double waterAmount = ISessionContext.WaterIntake.Amount;
        public double WaterAmount
        {
            get { return waterAmount; }
            set
            {
                waterAmount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("WaterAmount"));
            }
        }


        private void OnGridButtonPushed(object obj)
        {
            ImageButton btn = (ImageButton)obj;
            switch (btn.AutomationId)
            {
                case "50":
                    ISessionContext.WaterIntake.Amount += 50;
                    break;
                case "100":
                    ISessionContext.WaterIntake.Amount += 100;
                    break;
                case "150":
                    ISessionContext.WaterIntake.Amount += 150;
                    break;
                case "200":
                    ISessionContext.WaterIntake.Amount += 200;
                    break;
                case "250":
                    ISessionContext.WaterIntake.Amount += 250;
                    break;
            }
            WaterAmount = ISessionContext.WaterIntake.Amount;
        }

    }
}