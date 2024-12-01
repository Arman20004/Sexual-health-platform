using Microsoft.Maui.ApplicationModel.Communication;

namespace Sexual_health_platform
{
    public partial class MainPage : ContentPage
    {
        private string _username;
        private string _email;

        public MainPage(string username, string email)
        {
            InitializeComponent();
            _username = username;
            _email = email;
            DisplayUsername();
        }

        private void DisplayUsername()
        {
            WelcomeLabel.Text = $"HELLO, {_username.ToUpper()}";
        }

        private async void OpenChat(object sender, EventArgs e) => await Navigation.PushAsync(new ChatPage());
        private async void NavigateHome(object sender, EventArgs e) => await DisplayAlert("Navigation", "Home", "OK");
        private async void NavigateCalendar(object sender, EventArgs e) => await DisplayAlert("Navigation", "Calendar", "OK");
        private async void NavigateProfile(object sender, EventArgs e) => await Navigation.PushAsync(new ProfilePage(_username, _email));

    }
}

