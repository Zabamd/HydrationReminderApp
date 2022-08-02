using HydrationReminderApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HydrationReminderApp.Services
{
    /// <summary>
    /// Static class containing every database operation used in project
    /// </summary>
    public static class DataBaseService
    {
        //DB handler
        private static SQLiteConnection db;
        private static SQLiteConnection dbWater;

        /// <summary>
        ///  Inicialization of db for profile information
        /// </summary>
        private static void Init()
        {
            //if db exists don't reinitialize
            if (db != null)
                return;
            //Absolute path to db file
            var databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "Profile.db");
            //Table Creation
            db = new SQLiteConnection(databasePath);
            db.CreateTable<Profile>();
        }
        /// <summary>
        /// Inicialization of db for user data
        /// </summary>
        private static void InitData()
        {
            //if db exists don't reinitialize
            if (dbWater != null)
                return;
            //Absolute path to db file
            var databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "WaterIntake.db");
            //Table Creation
            dbWater = new SQLiteConnection(databasePath);
            dbWater.CreateTable<WaterIntake>();
        }
        /// <summary>
        /// Checks if user exists in db based on User.Username and User.Password and if password is correct
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool Login(User user)
        {
            Init();
            var check = db.Table<Profile>().Where(x => (x.Username == user.Username) && (x.Password == user.Password)).FirstOrDefault();
            if (check != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        ///  Creates new profile object and after checking if profile already exists in db, inserts it into db. Returns (string) message based on check
        /// </summary>
        public static string SignUp(string username, string password, string email, double weight, int workoutTime, double waterIntake)
        {
            Init();
            var profile = new Profile
            {
                Username = username,
                Password = password,
                Email = email,
                Weight = weight,
                WorkoutTime = workoutTime,
                WaterIntake = waterIntake

            };

            //Check if accound with identical email or username already exist in database
            var check = db.Table<Profile>().Where(x => (x.Username == profile.Username) || (x.Email == profile.Email)).FirstOrDefault();

            if (check == null)
            {
                db.Insert(profile);
                return "Succesfull Sign Up. Please Login";
            }
            else
            {
                return "Profile already exists. Please Login";
            }

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
