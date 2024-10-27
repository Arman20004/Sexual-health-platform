using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sexual_health_platform
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            // Here, implement your authentication logic (simplified for example)
            if (!string.IsNullOrEmpty(UsernameEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text))
            {
                await Navigation.PushAsync(new GenderSurveyPage());
            }
            else
            {
                await DisplayAlert("Error", "Please enter valid credentials.", "OK");
            }
        }
    }

}
