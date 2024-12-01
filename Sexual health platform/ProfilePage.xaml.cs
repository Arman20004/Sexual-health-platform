namespace Sexual_health_platform
{
    public partial class ProfilePage : ContentPage
    {
        public string Username { get; set; }
        public string Email { get; set; }

        public ProfilePage(string username, string email)
        {
            InitializeComponent();
            Username = username;
            Email = email;
            BindingContext = this;
        }

        private async void LogoutClicked(object sender, EventArgs e)
        {
            bool confirmLogout = await DisplayAlert("Log Out", "Are you sure you want to log out?", "Yes", "No");
            if (confirmLogout)
            {
                await Navigation.PopToRootAsync();
            }
        }
    }
}
