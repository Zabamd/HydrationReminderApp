namespace HydrationReminderApp.Models
{
    public class User
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }

    }
}
