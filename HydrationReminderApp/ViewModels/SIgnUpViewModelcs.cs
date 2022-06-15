﻿using HydrationReminderApp.Models;
using HydrationReminderApp.Services;
using HydrationReminderApp.Views;
using System;
using System.ComponentModel;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace HydrationReminderApp.ViewModels
{
    public class SignUpViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command SignupCommand { get; }
        public Command LoginCommand { get; }

        Profile newUser;

        private string message;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Message"));
            }
        }
        private bool messageCheck = false;
        public bool MessageCheck
        {
            get { return messageCheck; }
            set
            {
                messageCheck = value;
                PropertyChanged(this, new PropertyChangedEventArgs("MessageCheck"));
            }
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
        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
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
        private string repeatPassword;
        public string RepeatPassword
        {
            get { return repeatPassword; }
            set
            {
                repeatPassword = value;
                PropertyChanged(this, new PropertyChangedEventArgs("RepeatPassword"));
            }
        }
        private double weight = 0;
        public double Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Weight"));
            }
        }
        private int workoutTime = 0;
        public int WorkoutTime
        {
            get { return workoutTime; }
            set
            {
                workoutTime = value;
                PropertyChanged(this, new PropertyChangedEventArgs("WorkoutTime"));
            }
        }

        public SignUpViewModel()
        {
            SignupCommand = new Command(OnSignUpClicked);
            LoginCommand = new Command(OnLoginClicked);
        }
        private void OnSignUpClicked(object obj)
        {

            newUser = new Profile()
            {
                Username = username,
                Email = email,
                Password = password,
                Weight = weight,
                WorkoutTime = workoutTime,
                WaterIntake = WaterIntakeCalc(weight, workoutTime)
            };
            //Check for correct format
            if (PasswordChecks(newUser.Password, repeatPassword) && EmailCheck(newUser.Email))
            {
                Message = DataBaseService.SignUp(newUser.Username, newUser.Password, newUser.Email, newUser.Weight, newUser.WorkoutTime, newUser.WaterIntake);

                //Response
                MessageCheck = OnMessageDisplay(Message);
                
            }
            else
            {
                Message = "";
                if (!PasswordChecks(newUser.Password, repeatPassword))
                {
                    Message += "Password must contain one small character, one large character, one number and one special sign.\nPassword and repeated password must match.";
                    password = "";
                    repeatPassword = "";
                }
                if (EmailCheck(newUser.Email))
                {
                    Message += "Incorrect emial format";
                    email = "";
                }
            }
        
        }
        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            Message = "";
            MessageCheck = false;
            username = "";
            email = "";
            password = "";
            repeatPassword = "";
        }
        //Checks if password contains small character, large character, number and special sign using regex 
        private bool PasswordChecks(string password, string repeatedPassword)
        {
            //look for small character. large character, special sign and number
            string regex = "^(?=.*[a-z])(?=."
                            + "*[A-Z])(?=.*\\d)"
                            + "(?=.*[-+_!@#$%^&*., ?]).+$";
            Regex p = new Regex(regex);
            Match match = p.Match(password);

            if(match.Success && password.Length >= 8 && (password == repeatedPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Checks for correct email format
        private bool EmailCheck(string email)
        {
            //Regex checks if email format is correct
            string regex = @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                           + "@"
                           + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$";

            Regex p = new Regex(regex);
            Match match = p.Match(email);

            if(match.Success)
                return true;
            else
                return false;
        }
        // equation for required water intake in liters
        private double WaterIntakeCalc(double Weight, int WorkoutTime)
        { 
            //kg to pounds
            double WeightPounds = Weight * 2.2;
            double reqiredIntakeOnz = (WeightPounds * 0.5) + ((WorkoutTime / 30) * 12);

            //convertion onz to ml to liters
            return ((reqiredIntakeOnz * 29.57) / 1000);
        }
        //Based on message form db, change bool value of messageCheck that controls button display in SignUpPage.xaml
        private bool OnMessageDisplay(string response)
        {
            if(response == "Succesfull Sign Up. Please Login")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}