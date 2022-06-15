
using HydrationReminderApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HydrationReminderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {



        public ProfilePage()
        {
            InitializeComponent();
            this.BindingContext = new ProfileViewModel();
        }
        public async void AnimationWeightButton(object sender, EventArgs e)
        {
            UpdateWeightButton.TextColor = Color.Black;
            UpdateWeightButton.Background = Brush.LightGreen;
            UpdateWeightButton.Text = "Weight Updated";

            await UpdateWeightButton.TranslateTo(0, -5, 200, Easing.Linear);
            await UpdateWeightButton.TranslateTo(0, 5, 300, Easing.Linear);
            await UpdateWeightButton.TranslateTo(0, 0, 200, Easing.Linear);

            UpdateWeightButton.Background = Color.FromHex("#2196F3");
            UpdateWeightButton.Text = "Update weight";
            UpdateWeightButton.TextColor = Color.White;


        }
        public async void AnimationWorkoutButton(object sender, EventArgs e)
        {
            UpdateWorkoutButton.TextColor = Color.Black;
            UpdateWorkoutButton.Background = Brush.LightGreen;
            UpdateWorkoutButton.Text = "Workout Time Updated";

            await UpdateWorkoutButton.TranslateTo(0, -5, 200, Easing.Linear);
            await UpdateWorkoutButton.TranslateTo(0, 5, 300, Easing.Linear);
            await UpdateWorkoutButton.TranslateTo(0, 0, 200, Easing.Linear);

            UpdateWorkoutButton.Background = Color.FromHex("#2196F3");
            UpdateWorkoutButton.Text = "Update workout time";
            UpdateWorkoutButton.TextColor = Color.White;


        }
        public async void DeleteClicked(object sneder, EventArgs e)
        {
            DeleteAccount.Text = "Click again to confirm";
            await UpdateWorkoutButton.TranslateTo(-5, 0, 200, Easing.Linear);
            await UpdateWorkoutButton.TranslateTo(5, 0, 300, Easing.Linear);
            await UpdateWorkoutButton.TranslateTo(0, 0, 300, Easing.Linear);
        }
    }
}