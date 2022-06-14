using HydrationReminderApp.Models;
using HydrationReminderApp.Services;
using System.ComponentModel;
using Xamarin.Forms;

namespace HydrationReminderApp.ViewModels
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command SignupCommand { get; }

        private string process;
        public string Process
        {
            get { return process; }
            set
            {
                process = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Process"));
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

        public SignUpViewModel()
        {
            SignupCommand = new Command(OnSignUpClicked);
        }
        private void OnSignUpClicked(object obj)
        {
            double WaterIntakeCalc(double Weight, int WorkoutTime)
            {   //simple equation for required water intake in liters

                double WeightPounds = Weight * 2.2;
                double reqiredIntakeOnz = (WeightPounds * 0.5) * (WorkoutTime * 12);

                //convertion to liters
                return ((reqiredIntakeOnz * 29.57) / 1000);
            }

            var newUser = new Profile()
            {
                Username = username,
                Email = email,
                Password = password,
                Weight = 40,
                WorkoutTime = 40,
                WaterIntake = WaterIntakeCalc(40, 40)
            };
            if (PasswordChecks(newUser.Password))
                Process = DataBaseService.SignUp(newUser.Username, newUser.Password, newUser.Email, newUser.Weight, newUser.WorkoutTime);
            else; //error message

        }
        private bool PasswordChecks(string password)
        {
            bool isValid = true;
            if(password.Length <8 ) isValid = false;
            return isValid;
          
        }

        //ADD CHECKING PASSWORD
        //CONNECTION TO DB
        //MAIN SCREEN 
    }
}