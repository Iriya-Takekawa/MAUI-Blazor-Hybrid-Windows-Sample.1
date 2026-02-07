# Project Structure

Complete directory structure of the MAUI Blazor Hybrid Windows Sample.

```
MAUI-Blazor-Hybrid-Windows-Sample.1/
│
├── .git/                           # Git repository
├── .gitignore                      # Git ignore patterns
│
├── MauiBlazorApp.sln               # Visual Studio solution file
│
├── MauiBlazorApp/                  # Main application project
│   │
│   ├── Components/                 # Blazor UI components
│   │   ├── Layout/
│   │   │   ├── MainLayout.razor    # Main application layout
│   │   │   └── NavMenu.razor       # Navigation sidebar menu
│   │   ├── Pages/
│   │   │   ├── Home.razor          # Home page with app overview
│   │   │   ├── Categories.razor    # Categories CRUD page
│   │   │   ├── Items.razor         # Items CRUD page
│   │   │   ├── ExportImport.razor  # Database export/import page
│   │   │   ├── Report.razor        # Report template info page
│   │   │   └── Definition.razor    # Excel definition viewer page
│   │   ├── Routes.razor            # Routing configuration
│   │   └── _Imports.razor          # Global using statements
│   │
│   ├── Data/                       # Data access layer
│   │   └── AppDbContext.cs         # EF Core DbContext with tables
│   │
│   ├── Models/                     # Entity models
│   │   ├── Category.cs             # Category entity
│   │   └── Item.cs                 # Item entity
│   │
│   ├── Services/                   # Business logic services
│   │   ├── IReportService.cs       # Report service interface
│   │   ├── DummyReportService.cs   # Dummy report implementation
│   │   ├── IExcelDefinitionService.cs      # Excel service interface
│   │   ├── ExcelDefinitionService.cs       # Excel reader (EPPlus)
│   │   ├── IDataExportImportService.cs     # Export/Import interface
│   │   └── DataExportImportService.cs      # Export/Import (ZIP)
│   │
│   ├── Platforms/                  # Platform-specific code
│   │   └── Windows/                # Windows-specific (empty for now)
│   │
│   ├── Resources/                  # Application resources
│   │   ├── Fonts/
│   │   │   └── OpenSans-Regular.ttf        # Font file (placeholder)
│   │   ├── Images/                 # Image resources (empty)
│   │   ├── Raw/
│   │   │   ├── DataModel.xlsx      # Database schema definition
│   │   │   └── ReportTemplate.xlsx # Report template sample
│   │   ├── Styles/
│   │   │   ├── Colors.xaml         # Color definitions
│   │   │   └── Styles.xaml         # XAML styles
│   │   ├── appicon.svg             # Application icon
│   │   └── appiconfg.svg           # Application icon foreground
│   │
│   ├── wwwroot/                    # Web static files
│   │   ├── css/
│   │   │   ├── bootstrap/          # Bootstrap 5.3.0 CSS
│   │   │   │   ├── bootstrap.min.css
│   │   │   │   └── ...
│   │   │   ├── open-iconic/        # Open Iconic icon font
│   │   │   │   └── font/
│   │   │   │       ├── css/
│   │   │   │       └── fonts/
│   │   │   └── app.css             # Custom application CSS
│   │   └── index.html              # Blazor WebView host page
│   │
│   ├── App.xaml                    # MAUI application XAML
│   ├── App.xaml.cs                 # MAUI application code-behind
│   ├── MainPage.xaml               # Main page with BlazorWebView
│   ├── MainPage.xaml.cs            # Main page code-behind
│   ├── MauiProgram.cs              # App startup and DI configuration
│   └── MauiBlazorApp.csproj        # Project file with packages
│
└── Documentation/                  # (Root level documentation)
    ├── README.md                   # Main documentation (Japanese)
    ├── BUILD.md                    # Build instructions
    ├── ARCHITECTURE.md             # System architecture
    ├── UI_GUIDE.md                 # UI/UX guide
    ├── CHANGELOG.md                # Version history
    ├── CONTRIBUTING.md             # Contribution guidelines
    ├── LICENSE                     # MIT License
    ├── SUMMARY.md                  # Project summary
    └── PROJECT_STRUCTURE.md        # This file
```

## Key Files by Category

### Core Application Files
- `MauiBlazorApp.sln` - Visual Studio solution
- `MauiProgram.cs` - Application entry point and DI setup
- `App.xaml/cs` - MAUI application definition
- `MainPage.xaml/cs` - Main page with Blazor WebView

### Data Layer
- `Data/AppDbContext.cs` - EF Core context with Categories/Items tables
- `Models/Category.cs` - Category entity
- `Models/Item.cs` - Item entity

### UI Components (Blazor Razor)
- `Components/Routes.razor` - Router configuration
- `Components/Layout/MainLayout.razor` - App layout
- `Components/Layout/NavMenu.razor` - Navigation menu
- `Components/Pages/Home.razor` - Home page
- `Components/Pages/Categories.razor` - Categories CRUD
- `Components/Pages/Items.razor` - Items CRUD
- `Components/Pages/ExportImport.razor` - Export/Import UI
- `Components/Pages/Report.razor` - Report info
- `Components/Pages/Definition.razor` - Excel definition viewer

### Services
- `Services/IReportService.cs` - Report service interface
- `Services/DummyReportService.cs` - Dummy implementation
- `Services/IExcelDefinitionService.cs` - Excel service interface
- `Services/ExcelDefinitionService.cs` - Excel reader (EPPlus)
- `Services/IDataExportImportService.cs` - Export/Import interface
- `Services/DataExportImportService.cs` - ZIP export/import

### Resources
- `Resources/Raw/DataModel.xlsx` - Schema definition
- `Resources/Raw/ReportTemplate.xlsx` - Report template
- `Resources/Styles/Colors.xaml` - Color palette
- `Resources/Styles/Styles.xaml` - MAUI styles
- `Resources/appicon.svg` - App icon
- `wwwroot/css/bootstrap/` - Bootstrap CSS
- `wwwroot/css/open-iconic/` - Icons
- `wwwroot/css/app.css` - Custom CSS
- `wwwroot/index.html` - Blazor host

### Documentation
- `README.md` - Main guide (11KB, Japanese)
- `BUILD.md` - Build guide (7KB)
- `ARCHITECTURE.md` - Architecture (12KB)
- `UI_GUIDE.md` - UI guide (17KB)
- `CHANGELOG.md` - Changes (4KB)
- `CONTRIBUTING.md` - Contributing (5KB)
- `LICENSE` - License (2KB)
- `SUMMARY.md` - Summary (8KB)
- `PROJECT_STRUCTURE.md` - This file (6KB)

## File Count Summary

```
Type                    Count
─────────────────────────────
C# Files                  12
Razor Components          10
XAML Files                 4
Project/Solution Files     2
Excel Files                2
Documentation Files        9
CSS/Style Files          30+
Icon/Font Files          20+
Configuration Files        3
─────────────────────────────
Total Core Files          92+
```

## Important Paths

### Development
- Solution: `MauiBlazorApp.sln`
- Project: `MauiBlazorApp/MauiBlazorApp.csproj`
- Entry Point: `MauiBlazorApp/MauiProgram.cs`

### Runtime
- Database: `FileSystem.AppDataDirectory/app.db`
- Excel Definition: `AppContext.BaseDirectory/DataModel.xlsx`
- Report Template: `AppContext.BaseDirectory/ReportTemplate.xlsx`

### Export/Import
- Default Export: `Documents/MauiBlazorApp_Exports/`
- Export Format: `database_export_YYYYMMDD_HHMMSS.zip`

## NuGet Packages

Defined in `MauiBlazorApp/MauiBlazorApp.csproj`:

```xml
<PackageReference Include="Microsoft.Maui.Controls" Version="8.0.90" />
<PackageReference Include="Microsoft.AspNetCore.Components.WebView.Maui" Version="8.0.90" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="8.0.10" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.10" />
<PackageReference Include="EPPlus" Version="7.5.1" />
```

## Build Outputs

After building, the following additional directories are created:

```
MauiBlazorApp/
├── bin/
│   └── Debug|Release/
│       └── net8.0-windows10.0.19041.0/
│           └── win-x64/
│               ├── MauiBlazorApp.exe
│               ├── *.dll files
│               ├── DataModel.xlsx
│               └── ReportTemplate.xlsx
└── obj/
    └── (intermediate build files)
```

## Development Workflow

1. **Edit Code**: Modify `.cs`, `.razor`, or `.xaml` files
2. **Build**: `dotnet build` or F6 in Visual Studio
3. **Run**: `dotnet run` or F5 in Visual Studio
4. **Test**: Manual testing on Windows
5. **Commit**: Git commit changes
6. **Document**: Update README/CHANGELOG as needed

## Extension Points

Files to modify for customization:

- **Report Service**: Replace `DummyReportService.cs`
- **Grid Components**: Edit `Items.razor`, `Categories.razor`
- **Database**: Modify `AppDbContext.cs`, add new entities
- **Excel Processing**: Extend `ExcelDefinitionService.cs`
- **UI Styling**: Edit `wwwroot/css/app.css`, `Resources/Styles/*.xaml`
- **Services**: Add new services in `Services/` folder

## Notes

- All `.cs` files use `namespace MauiBlazorApp.*`
- Razor components use `@namespace MauiBlazorApp.Components.*`
- Resources are embedded and copied to output
- Excel files must be in `Resources/Raw/` with `CopyToOutputDirectory=PreserveNewest`
- Bootstrap and Open Iconic are included locally (no CDN)

This structure provides a clean, maintainable, and extensible MAUI Blazor application.
