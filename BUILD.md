# MAUI Blazor Hybrid Windows Sample - Build Guide

## Prerequisites

### Required Software
1. **Windows 10 version 1809 or later** (for development and deployment)
2. **Visual Studio 2022** (version 17.8 or later) with the following workloads:
   - .NET Multi-platform App UI development
   - Windows application development

Or

3. **.NET SDK 8.0** or **.NET SDK 9.0**
   - Download from: https://dotnet.microsoft.com/download
4. **Windows SDK 10.0.17763.0** or later

### Installing .NET MAUI Workload (Command Line)

If using command line tools, install the MAUI workload:

```bash
dotnet workload install maui
```

## Building the Project

### Using Visual Studio 2022

1. Open `MauiBlazorApp.sln` in Visual Studio 2022
2. Select the target framework: `net8.0-windows10.0.19041.0`
3. Set the build configuration to `Debug` or `Release`
4. Select `Windows Machine` as the target device
5. Press F5 to build and run, or use menu: `Build > Build Solution`

### Using Command Line

Navigate to the project directory:

```bash
cd MauiBlazorApp
```

#### Restore NuGet packages:

```bash
dotnet restore
```

#### Build the project:

```bash
dotnet build -f net8.0-windows10.0.19041.0 -c Release
```

#### Run the project:

```bash
dotnet run -f net8.0-windows10.0.19041.0
```

## Publishing the Application

### Create a deployable package:

```bash
dotnet publish -f net8.0-windows10.0.19041.0 -c Release -p:PublishSingleFile=true -p:SelfContained=true -p:RuntimeIdentifier=win-x64
```

The published files will be in:
```
MauiBlazorApp\bin\Release\net8.0-windows10.0.19041.0\win-x64\publish\
```

### Create MSIX package (for Windows Store or enterprise deployment):

```bash
dotnet publish -f net8.0-windows10.0.19041.0 -c Release -p:GenerateAppxPackageOnBuild=true
```

## Project Structure Overview

```
MauiBlazorApp/
├── Components/              # Blazor UI Components
│   ├── Layout/             # Layout components (MainLayout, NavMenu)
│   └── Pages/              # Page components (Home, Categories, Items, etc.)
├── Data/                   # EF Core DbContext
├── Models/                 # Entity models (Category, Item)
├── Services/               # Business logic services
│   ├── IReportService.cs
│   ├── DummyReportService.cs
│   ├── IExcelDefinitionService.cs
│   ├── ExcelDefinitionService.cs
│   ├── IDataExportImportService.cs
│   └── DataExportImportService.cs
├── Resources/              # Application resources
│   ├── Raw/
│   │   ├── DataModel.xlsx      # Database schema definition
│   │   └── ReportTemplate.xlsx # Report template
│   ├── Styles/             # XAML styles
│   └── Fonts/              # Font files
├── wwwroot/                # Web static files
│   ├── css/
│   │   ├── bootstrap/      # Bootstrap CSS framework
│   │   ├── open-iconic/    # Open Iconic icons
│   │   └── app.css         # Custom styles
│   └── index.html          # Blazor WebView host page
├── MauiProgram.cs          # App startup and DI configuration
├── App.xaml / App.xaml.cs  # MAUI application
└── MainPage.xaml           # Main page with BlazorWebView
```

## Key Features

### 1. SQLite Database
- Location: `FileSystem.AppDataDirectory/app.db`
- Automatically created on first run
- Uses Entity Framework Core with migrations
- Two tables: Categories and Items

### 2. CRUD Operations
- **Categories**: Full CRUD (Create, Read, Update, Delete)
- **Items**: Full CRUD with Category foreign key relationship
- Standard HTML table UI (easily replaceable with advanced grids)

### 3. Excel Definition File
- **DataModel.xlsx**: Contains database schema definition
- Two sheets: "Tables" and "Columns"
- Read on startup to validate schema
- Uses EPPlus library for Excel operations

### 4. Export/Import
- Export database to ZIP file
- Import database from ZIP file
- Default export location: `Documents\MauiBlazorApp_Exports\`

### 5. Report Service
- **IReportService** interface for extensibility
- Dummy implementation shows template path
- Ready for AS-Report/SpreadsheetGear integration

## Dependencies

The project uses the following NuGet packages:

- **Microsoft.Maui.Controls** (8.0.90): MAUI framework
- **Microsoft.AspNetCore.Components.WebView.Maui** (8.0.90): Blazor integration
- **Microsoft.EntityFrameworkCore.Sqlite** (8.0.10): SQLite database provider
- **Microsoft.EntityFrameworkCore.Design** (8.0.10): EF Core design-time components
- **EPPlus** (7.5.1): Excel file operations

## Troubleshooting

### Error: "NETSDK1100: To build a project targeting Windows"
This error occurs when building on non-Windows platforms. This project requires Windows for building and running.

### Error: "Cannot find package Microsoft.Maui.Controls"
Install the MAUI workload:
```bash
dotnet workload install maui
```

### Error: Database not created
- Check if the application has write permissions to `FileSystem.AppDataDirectory`
- Try running the application as administrator
- Check the application logs for database initialization errors

### Excel file not found
- Verify that `DataModel.xlsx` and `ReportTemplate.xlsx` are in `Resources/Raw/`
- Check that the `.csproj` file has `<CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>` for these files
- Clean and rebuild the project

## Running Tests

Currently, this is a sample project without unit tests. To add tests:

1. Create a new test project:
```bash
dotnet new xunit -n MauiBlazorApp.Tests
```

2. Add reference to the main project:
```bash
cd MauiBlazorApp.Tests
dotnet add reference ../MauiBlazorApp/MauiBlazorApp.csproj
```

3. Run tests:
```bash
dotnet test
```

## Development Notes

### Database Migrations

To create a new migration:
```bash
dotnet ef migrations add MigrationName
```

To update database:
```bash
dotnet ef database update
```

### Debugging

- Set breakpoints in Visual Studio
- Use Developer Tools for Blazor (F12 in debug mode)
- Check console output for errors
- Database location for inspection: `%LocalAppData%\Packages\[AppId]\LocalState\app.db`

## Next Steps

1. **Replace Grid Component**: Consider using Telerik, Syncfusion, or DevExpress grids
2. **Implement Real Report Service**: Integrate AS-Report or SpreadsheetGear
3. **Add Validation**: Implement data validation attributes on models
4. **Add Authentication**: Implement user authentication if needed
5. **Add Logging**: Implement structured logging with Serilog
6. **Add Error Handling**: Implement global error handling
7. **Performance Optimization**: Add caching and query optimization

## License Notes

- **EPPlus**: This project uses EPPlus with NonCommercial license context. For commercial use, purchase a license.
- **Bootstrap**: MIT License
- **Open Iconic**: MIT License
- **.NET MAUI**: MIT License

## Support

For issues and questions:
- Create an issue on GitHub
- Check MAUI documentation: https://docs.microsoft.com/dotnet/maui/
- Check Blazor documentation: https://docs.microsoft.com/aspnet/core/blazor/
