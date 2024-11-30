using Microsoft.EntityFrameworkCore;
using Sexual_health_platform.Data;

namespace Sexual_health_platform
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
               .UseSqlServer("Server=tcp:sexual-health-platform.database.windows.net,1433;Initial Catalog=Sexual_health_platform;Persist Security Info=False;User ID=Armin;Password=G1@di)lus=_=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
               .Options;

            var dbContext = new AppDbContext(dbContextOptions);

            bool isRegistered = Preferences.Get("IsRegistered", false);

            var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=tcp:sexual-health-platform.database.windows.net,1433;Initial Catalog=Sexual_health_platform;Persist Security Info=False;User ID=Armin;Password=G1@di)lus=_=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;")
            .Options;

            MainPage = isRegistered
            ? new NavigationPage(new MainPage()) // Already registered user
            : new NavigationPage(new RegistrationPage(dbContext)); // New user
        }
    }
}
