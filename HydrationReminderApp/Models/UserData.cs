using SQLite;
using System;

namespace HydrationReminderApp.Models
{   /// <summary>
    /// Table Used for storing  User 
    /// </summary>
    [Table("UserData")]
    public class UserData
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        [Column("Username")]
        public string Username { get; set; }
        [Column("Amount")]
        public int Amount { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
    }
}