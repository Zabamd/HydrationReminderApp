using HydrationReminderApp.Models;
using SQLite;
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
        private static SQLiteConnection dbData;

        /// <summary>
        ///  Inicialization of db for profile information
        /// </summary>
        public static void Init()
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
        public static void InitData()
        {
            //if db exists don't reinitialize
            if (dbData != null)
                return;
            //Absolute path to db file
            var databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "UserData.db");
            //Table Creation
            dbData = new SQLiteConnection(databasePath);
            dbData.CreateTable<UserData>();
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
