using HydrationReminderApp.Models;
namespace HydrationReminderApp.ViewModels
{
    /// <summary>
    /// Class Used to exchange Profile data between ViewModels and recalculate water intake
    /// </summary>
    public class ISessionContext
    {
        public static Profile Profile { get; set; }
        // equation for required water intake in liters
        public static double WaterIntakeCalc(double Weight, int WorkoutTime)
        {
            //kg to pounds
            double WeightPounds = Weight * 2.2;
            double reqiredIntakeOnz = (WeightPounds * 0.5) + ((WorkoutTime / 30) * 12);

            //convertion onz to ml to liters
            return ((reqiredIntakeOnz * 29.57) / 1000);
        }
    }
}
