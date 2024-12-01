using System;
using System.Linq;
using Microsoft.Maui.Controls;
using Microsoft.EntityFrameworkCore;
using Sexual_health_platform.Data;

namespace Sexual_health_platform
{
    public partial class LoginPage : ContentPage
    {
        private readonly AppDbContext _dbContext;

        public LoginPage(AppDbContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UsernameEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
            {
                await DisplayAlert("Error", "Please fill all fields.", "OK");
                return;
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == UsernameEntry.Text || u.Email == EmailEntry.Text);

            if (user == null)
            {
                await DisplayAlert("Error", "Invalid username or password.", "OK");
                return;
            }
            
            if (!BCrypt.Net.BCrypt.Verify(PasswordEntry.Text, user.PasswordHash))
            {
                await DisplayAlert("Error", "Invalid username or password.", "OK");
                return;
            }

            Preferences.Set("IsRegistered", true);

            await Navigation.PushAsync(new MainPage());
        }
    }
}
