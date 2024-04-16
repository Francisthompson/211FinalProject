using Microsoft.Extensions.Logging;
using System.IO; // Add this for Path.Combine
using System; // Add this for Environment
using Microsoft.Extensions.DependencyInjection;
using EndToEnd.Data; // Add this for ActivatorUtilities

namespace MauiApp29
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // Set path to the SQLite database (it will be created if it does not exist)
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Reservations.db");

            // Register WeatherForecastService and the SQLite database
            builder.Services.AddSingleton<ReservationService>(
                s => ActivatorUtilities.CreateInstance<ReservationService>(s, dbPath));

            return builder.Build();
        }
    }
}
