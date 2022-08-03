using SQLite;

namespace HydrationReminderApp.Models
{
    /// <summary>
    /// Tabel used for account personal data 
    /// </summary>
    public class Profile
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public double Weight { get; set; }

        public int WorkoutTime { get; set; }

        public double WaterIntake { get; set; }
    }
}