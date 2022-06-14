using HydrationReminderApp.Models;
using HydrationReminderApp.Services;
using HydrationReminderApp.Views;
using System.ComponentModel;
using Xamarin.Forms;

namespace HydrationReminderApp.ViewModels
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command SignupCommand { get; }
        public Command LoginCommand { get; }

        Profile newUser;

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Message"));
            }
        }
        private bool messageCheck = false;
        public bool MessageCheck
        {
            get { return messageCheck; }
            set
            {
                messageCheck = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MessageCheck"));
            }
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
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
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
        private string repeatPassword;
        public string RepeatPassword
        {
            get { return repeatPassword; }
            set
            {
                repeatPassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RepeatPassword"));
            }
        }
        private double weight = 0;
        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Weight"));
            }
        }
        private int workoutTime = 0;
        public int WorkoutTime
        {
            get { return workoutTime; }
            set
            {
                workoutTime = value;
                PropertyChanged(this, new PropertyChangedEventArgs("WorkoutTime"));
            }
        }

        public SignUpViewModel()
        {
            SignupCommand = new Command(OnSignUpClicked);
            LoginCommand = new Command(OnLoginClicked);
        }
        private void OnSignUpClicked(object obj)
        {
            double WaterIntakeCalc(double Weight, int WorkoutTime)
            {   //simple equation for required water intake in liters

                double WeightPounds = Weight * 2.2;
                double reqiredIntakeOnz = (WeightPounds * 0.5) + ((WorkoutTime/30) * 12);

                //convertion to liters
                return ((reqiredIntakeOnz * 29.57) / 1000);
            }

            newUser = new Profile()
            {
                Username = username,
                Email = email,
                Password = password,
                Weight = weight,
                WorkoutTime = workoutTime,
                WaterIntake = WaterIntakeCalc(weight, workoutTime)
            };
            if (PasswordChecks(newUser.Password))
            {
                Message = DataBaseService.SignUp(newUser.Username, newUser.Password, newUser.Email, newUser.Weight, newUser.WorkoutTime, newUser.WaterIntake);
                MessageCheck = OnMessageDisplay(Message);
                
            }
            else;
        
        }
        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        private bool PasswordChecks(string password)
        {
            bool isValid = true;
            if(password.Length <8 ) isValid = false;
            if (password.Length < 8) isValid = false;
            return isValid;
          
        }
        private bool OnMessageDisplay(string response)
        {
            if(response == "Succesfull Sign Up. Please Login")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //ADD CHECKING PASSWORD
        //CONNECTION TO DB
        //MAIN SCREEN 
    }
}