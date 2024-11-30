using Sexual_health_platform.Data;
using System;

namespace Sexual_health_platform
{
    public partial class AgeSelectionPage : ContentPage
    {
        private readonly AppDbContext _dbContext;
        private readonly string _username;
        private readonly string _passwordHash;
        private readonly string _email;
        private int _age;

        public AgeSelectionPage(AppDbContext dbContext, string username, string passwordHash, string email)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _username = username;
            _passwordHash = passwordHash;
            _email = email;
        }

        private async void OnNextButtonClicked(object sender, EventArgs e)
        {
            var birthdate = BirthdatePicker.Date;
            _age = CalculateAge(birthdate);

            if (_age <= 7)
            {
                await DisplayAlert("Error", "Please select a valid birthdate.", "OK");
                return;
            }

            await Navigation.PushAsync(new GenderSurveyPage(_dbContext, _username, _passwordHash, _age, _email));
        }

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
