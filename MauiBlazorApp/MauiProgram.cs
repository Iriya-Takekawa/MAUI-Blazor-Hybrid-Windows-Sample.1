using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MauiBlazorApp.Data;
using MauiBlazorApp.Services;

namespace MauiBlazorApp;

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
        builder.Services.AddLogging(logging =>
        {
            logging.AddDebug();
        });
#endif

        // Configure SQLite database
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite($"Data Source={dbPath}"));
        builder.Services.AddDbContextFactory<AppDbContext>(options =>
            options.UseSqlite($"Data Source={dbPath}"));

        // Register services
        builder.Services.AddSingleton<IReportService, DummyReportService>();
        builder.Services.AddSingleton<IExcelDefinitionService, ExcelDefinitionService>();
        builder.Services.AddSingleton<IDataExportImportService, DataExportImportService>();

        var app = builder.Build();

        // Initialize database
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated();
        }

        return app;
    }
}
