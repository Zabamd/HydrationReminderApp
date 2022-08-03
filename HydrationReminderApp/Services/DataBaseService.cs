using HydrationReminderApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;

namespace HydrationReminderApp.Services
{
    /// <summary>
    /// Static class containing every database operation used in project
    /// </summary>
    public static class DataBaseService
    {
        //DB handler
        private static SqlConnectionStringBuilder _builder;

        /// <summary>
        ///  Inicialization of db for profile information
        /// </summary>
        private static SqlConnection  Init()
        {
            _builder = new SqlConnectionStringBuilder()
            {
                DataSource = "zabamd-hydration-app.database.windows.net",
                UserID = "Zabamd",
                Password = "$Admin11",
                InitialCatalog = "Userdb"

            };
            
            return new SqlConnection(_builder.ConnectionString);
        }

        public static bool ChceckIfValid(User user)
        {
            var connection = Init();
            connection.Open();
            var query = "SELECT * " 
                        + "FROM Profiles " 
                        + $"WHERE Username = {user.Username} AND Password = {user.Password}";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            bool result = reader.HasRows;
            
            connection.Close();
            reader.Close();
            
            return result;
        }
        public static Profile Login(User user)
        {
            var connection = Init();
            connection.Open();

            List<Profile> result = new List<Profile>();

            var query = "SELECT * " 
                            + "FROM Profiles " 
                            + $"WHERE Username={user.Username} AND Password = {user.Password}";

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new Profile()
                {
                    Id = (int)reader["Id"],
                    Username = (string)reader["Username"],
                    Password = (string)reader["Password"],
                    Email = (string)reader["Email"],
                    Weight = (double)reader["Weight"],
                    WorkoutTime = (int)reader["WorkoutTime"],
                    WaterIntake = (double)reader["WaterIntake"],
                });
            }

            connection.Close();
            reader.Close();
            
            return result[0];
        }
        /// <summary>
        ///  Creates new profile object and after checking if profile already exists in db, inserts it into db. Returns (string) message based on check
        /// </summary>
        public static string SignUp(Profile profile )
        {
            var connection = Init();
            connection.Open();

            bool check = ChceckIfValid(new User(profile.Username, profile.Password));

            if (check)
            {
                InsertProfile(profile);
                return "Succesfull Sign Up. Please Login";
            }
            else
            {
                return "Profile already exists. Please Login";
            }

        }

        public static void InsertProfile(Profile profile)
        {
            var query = "INSERT INTO Profiles VALUES {profile.Username}";
        }
        /// <summary>
        /// Delete account based in passed (Profile) id.
        /// </summary>
        /// <param name="id"></param>
        public static void DeleteAccount(int id)
        {
            Init();
            db.Delete<Profile>(id);

        }
        /// <summary>
        /// Updates profile data in db based on passed (Profile) profile.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public static void UpdateProfile(Profile profile)
        {
            Init();
            db.Update(profile);

        }
        /// <summary>
        /// Retrieve Profile data frome db based of User.username and User.Password. Returns (Profile) profile data
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static Profile GetProfileData(string username, string password)
        {
            Init();
            var query = from s in db.Table<Profile>()
                        where s.Username == username && s.Password == password
                        select s;

            return query.FirstOrDefault();
        }
        //PROFILE TABLE ENDS

        //DATA TABLE STARTS
        /// <summary>
        /// Method for retriveing data from db for plotting a graph
        /// </summary>
        public static List<WaterIntake> ReadData(WaterIntake waterIntake)
        {

            InitData();
            var query = from s in db.Table<WaterIntake>()
                        where s.Username == waterIntake.Username
                        select s;

            return query.ToList<WaterIntake>();
        }
        /// <summary>
        /// Method for adding data to the db
        /// </summary>
        public static void UpdateData(WaterIntake waterIntake)
        {
            InitData();
            dbWater.Insert(waterIntake);


        }
        /// <summary>
        /// Method for retriveing amount of water consumed today
        /// </summary>
        public static WaterIntake CheckToday(DateTime date, WaterIntake waterIntake)
        {
            InitData();
            var query = from s in db.Table<WaterIntake>()
                        where s.Username == waterIntake.Username && s.Date == waterIntake.Date
                        select s;

            return query.LastOrDefault();
        }

    }
}
