using SQLite;

namespace HydrationReminderApp.Models
{   /// <summary>
    /// Tabel used for account personal data 
    /// </summary>
    [Table("Profile")]
    public class Profile
    {

        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Username")]
        public string Username { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("Weight")]
        public double Weight { get; set; }
        [Column("WorkoutTime")]
        public int WorkoutTime { get; set; }
        [Column("WaterIntake")]
        public double WaterIntake { get; set; }




    }
}