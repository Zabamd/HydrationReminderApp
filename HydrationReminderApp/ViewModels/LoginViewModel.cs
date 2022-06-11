using HydrationReminderApp.Views;
using HydrationReminderApp.Models;
using Xamarin.Forms;
using System.ComponentModel;

namespace HydrationReminderApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command LoginCommand { get; }
        public Command SigninCommand { get; }


        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
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

        private async void OnLoginClicked(object obj)
        {
            var user = new User(username, password);

            bool IsValid = ChceckCredentials(user);
      

            if (IsValid)
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            else;
                
        }
        private bool ChceckCredentials(User user)
        {
            if (user.Username == "kaczka" && user.Password == "123") return true; else return false;
        }
    }
}
