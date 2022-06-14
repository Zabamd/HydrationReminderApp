using System.ComponentModel;
using HydrationReminderApp.Models;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;

namespace HydrationReminderApp.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static Profile profile = LoginViewModel.Profile;

        public  Command UpdateWeightClicked { get; }
        public Command UpdateWorkoutClicked { get; }
        public ProfileViewModel()
        {
            UpdateWeightClicked = new Command(OnUpdateWeightClicked);
            UpdateWorkoutClicked = new Command(OnUpdateWorkoutClicked);
        }
        public string Username { get; set; } = profile.Username;
        public double Weight { get; set; } = profile.Weight;

        public int WorkoutTime { get; set; } = profile.WorkoutTime;

        private  void OnUpdateWeightClicked(object obj)
        {
           
        }
     
        private void OnUpdateWorkoutClicked(object obj)
        {
           
        }
       
    }
}