using HydrationReminderApp.Models;
using HydrationReminderApp.Services;
using HydrationReminderApp.Views;
using System.ComponentModel;
using Xamarin.Forms;

namespace HydrationReminderApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command LoginCommand { get; }
        public Command SignupCommand { get; }

        public static Profile Profile { get; set; }

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

            bool IsValid = DataBaseService.Login(user);


            if (IsValid)
            {
                Profile = DataBaseService.GetProfileData(user.Username, user.Password);
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else;

              

        }
        private async void OnSignUp(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(SignUpPage)}");
        }



    }
}
