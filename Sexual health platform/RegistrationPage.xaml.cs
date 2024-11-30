using Microsoft.EntityFrameworkCore;
using Sexual_health_platform.Data;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sexual_health_platform
{
    public partial class RegistrationPage : ContentPage
    {
        private readonly AppDbContext _dbContext;
        private string _username;
        private string _passwordHash;
        private string _email;

        public RegistrationPage(AppDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            _username = UsernameEntry.Text?.Trim();
            _email = EmailEntry.Text?.Trim();
            var password = PasswordEntry.Text?.Trim();
            var confirmPassword = ConfirmPasswordEntry.Text?.Trim();

            if (string.IsNullOrWhiteSpace(_username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(_email))
            {
                await DisplayAlert("Error", "Please fill out all fields.", "OK");
                return;
            }

            if (password != confirmPassword)
            {
                await DisplayAlert("Error", "Passwords do not match. Please try again.", "OK");
                return;
            }

            if (!IsValidEmail(_email))
            {
                await DisplayAlert("Error", "Please enter a valid email address.", "OK");
                return;
            }

            _passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

            bool isEmailVerified = await SimulateEmailVerification(_email);

            if (!isEmailVerified)
            {
                await DisplayAlert("Error", "Email verification failed.", "OK");
                return;
            }

            await Navigation.PushAsync(new AgeSelectionPage(_dbContext, _username, _passwordHash, _email));
        }

        private bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        private async Task<bool> SimulateEmailVerification(string email)
        {
            await DisplayAlert("Email Verification", $"A verification code has been sent to {email}. Please verify your email to continue.", "OK");

            string verificationCode = await DisplayPromptAsync("Email Verification", "Enter the verification code sent to your email:");

            return verificationCode == "123456";
        }
    }
}
