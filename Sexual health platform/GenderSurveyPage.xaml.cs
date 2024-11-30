using Sexual_health_platform.Data;
using System;

namespace Sexual_health_platform
{
    public partial class GenderSurveyPage : ContentPage
    {
        private readonly AppDbContext _dbContext;
        private readonly string _username;
        private readonly string _passwordHash;
        private readonly int _age;
        private readonly string _email;

        public GenderSurveyPage(AppDbContext dbContext, string username, string passwordHash, int age, string email)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _username = username;
            _passwordHash = passwordHash;
            _age = age;
            _email = email;
        }

        private async void OnSubmitButtonClicked(object sender, EventArgs e)
        {
            var gender = GenderPicker.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(gender))
            {
                await DisplayAlert("Error", "Please select a gender.", "OK");
                return;
            }

            var newUser = new User
            {
                Username = _username,
                PasswordHash = _passwordHash,
                Age = _age,
                Gender = gender,
                Email = _email
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();

            await DisplayAlert("Success", "Registration completed successfully.", "OK");

            await Navigation.PushAsync(new MainPage());
        }
    }
}
