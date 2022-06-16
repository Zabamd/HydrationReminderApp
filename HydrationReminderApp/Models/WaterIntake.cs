using SQLite;
using System;

namespace HydrationReminderApp.Models
{   /// <summary>
    /// Table Used for storing  User water intake data 
    /// </summary>
    [Table("UserData")]
    public class WaterIntake
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        [Column("Username")]
        public string Username { get; set; }
        //Amount of consumed water
        [Column("Amount")]
        public double Amount { get; set; }
        //Calculated water intake amount
        [Column("ExpectedAmount")]
        public double ExpectedAmount { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
    }
}