using HydrationReminderApp.Models;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HydrationReminderApp.Services
{
    public static class DataBaseService
    {
        //DB handler
        private static SQLiteConnection db;
        private static SQLiteConnection dbData;

        public static void Init()
        {
            if (db != null)
                return;
            //Absolute path to db file
            var databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "Profile.db");
            //Table Creation
            db = new SQLiteConnection(databasePath);
            db.CreateTable<Profile>();
        }
        public static void InitData()
        {
            if (dbData != null)
                return;
            //Absolute path to db file
            var databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "UserData.db");
            //Table Creation
            dbData = new SQLiteConnection(databasePath);
            dbData.CreateTable<UserData>();
        }

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
        //SignUp Method -> creates new profile object and after checking if profile already exists in db inserts it into it;
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
        //Delete account method
        public static void DeleteAccount(int id)
        {
            Init();
            db.Delete<Profile>(id);

        }
        public static void UpdateProfile()
        {
            Init();
            // db.Update<Profile>();
        }
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
        public static void ReadData()
        {

            InitData();
        }
        public static void AddData()
        {
            InitData();
        }
      
    }
}
