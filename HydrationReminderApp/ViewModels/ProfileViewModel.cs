using System.ComponentModel;
using HydrationReminderApp.Models;
using HydrationReminderApp.Views;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;
using HydrationReminderApp.Services;

namespace HydrationReminderApp.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public  Command UpdateWeightClicked { get; }
        public Command UpdateWorkoutClicked { get; }
        public Command DeleteAccountClicked { get; }
        public ProfileViewModel()
        {
            UpdateWeightClicked = new Command(OnUpdateWeightClicked);
            UpdateWorkoutClicked = new Command(OnUpdateWorkoutClicked);
            DeleteAccountClicked = new Command(OnDeleteAccountClicked);
        }
        public string Username { get;} = ISessionContext.Profile.Username;
        private double weight = ISessionContext.Profile.Weight;
        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Weight"));
            }
        }

        private int workoutTime = ISessionContext.Profile.WorkoutTime;
        public int WorkoutTime
        {
            get { return workoutTime; }
            set
            {
                workoutTime = value;
                PropertyChanged(this, new PropertyChangedEventArgs("WorkoutTime"));
            }
        }
        private bool deleteConfirm = false;
        private  void OnUpdateWeightClicked(object obj)
        {
            ISessionContext.Profile.Weight = weight;
            ISessionContext.Profile = DataBaseService.UpdateProfile(ISessionContext.Profile);
        }
     
        private void OnUpdateWorkoutClicked(object obj)
        {
            ISessionContext.Profile.WorkoutTime = WorkoutTime;
            ISessionContext.Profile = DataBaseService.UpdateProfile(ISessionContext.Profile);
        }
        private async void OnDeleteAccountClicked(object ob)
        {
            //delete account after user confirms deletion
            if (deleteConfirm)
            {
                deleteConfirm = false;
                DataBaseService.DeleteAccount(ISessionContext.Profile.Id);
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
            else
            {
                deleteConfirm=true;
            }
        }


    }
}