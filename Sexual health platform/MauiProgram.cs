using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sexual_health_platform.Data;

namespace Sexual_health_platform
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Server=tcp:sexual-health-platform.database.windows.net,1433;Initial Catalog=Sexual_health_platform;Persist Security Info=False;User ID=Armin;Password=G1@di)lus=_=;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;",
                sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()));

            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
