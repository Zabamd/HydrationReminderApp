using HydrationReminderApp.Models;
using HydrationReminderApp.Services;
using HydrationReminderApp.Views;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace HydrationReminderApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command LoginCommand { get; }
        public Command SignupCommand { get; }



        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            SignupCommand = new Command(OnSignUp);


        }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        //needs fixing
        public string errorMessage = "";
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
            }
        }

        private async void OnLoginClicked(object obj)
        {
            var user = new User(username, password);

            bool isValid = DataBaseService.ChceckIfValid(user);


            if (isValid)
            {
                SessionInit(user);

                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else
            {
                errorMessage = "Incorrect username or password";
            }



        }
        private async void OnSignUp(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
        }
        
        //Initialising current session
        private void SessionInit(User user)
        {
            ISessionContext.Profile = DataBaseService.Login(user);

            DateTime date = DateTime.Now;

            var waterIntake = new WaterIntake()
            {
                Username = ISessionContext.Profile.Username,
                ExpectedAmount = ISessionContext.Profile.WaterIntake,
                Date = date.ToString(),
            };

            ISessionContext.WaterIntake = waterIntake;
            
            if (DataBaseService.CheckToday(date, ISessionContext.WaterIntake) is null)
            {
                ISessionContext.WaterIntake.Amount = 0;
            }
            else
            {
                ISessionContext.WaterIntake.Amount = DataBaseService.CheckToday(date, ISessionContext.WaterIntake).Amount;
            }

        }



    }
}
