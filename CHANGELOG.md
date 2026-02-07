# Changelog

All notable changes to this project will be documented in this file.

## [1.0.0] - 2026-02-07

### Added

#### Core Features
- Initial release of MAUI Blazor Hybrid Windows Sample application
- SQLite database with Entity Framework Core integration
- Automatic database creation on first run
- Two-table schema: Categories and Items

#### Database Features
- **ID Strategy**: Internal numeric ID (INTEGER PK AUTOINCREMENT) + external BusinessKey (Code TEXT)
- **Entities**:
  - Category: Id, Code, Name
  - Item: Id, Code, Name, CategoryId (FK), Amount, Note
- Seed data for initial demonstration
- Entity Framework Core with SQLite provider

#### UI Components
- Home page with application overview and database status
- Categories page with full CRUD operations
- Items page with full CRUD operations and Category combobox
- Export/Import page for database backup and restore
- Report page showing template information
- Excel Definition page displaying DataModel.xlsx content
- Responsive navigation menu
- Bootstrap 5.3.0 styling
- Open Iconic icons

#### Excel Definition System
- **DataModel.xlsx**: Database schema definition file
- Two sheets: Tables and Columns
- Excel reading service using EPPlus
- Validation and display of schema on startup
- Extensible for future dynamic schema generation

#### Export/Import Functionality
- Export database to ZIP file
- Import database from ZIP file
- Automatic backup before import
- Default export location: Documents\MauiBlazorApp_Exports\
- Timestamp-based file naming

#### Report Service
- **IReportService** interface for extensibility
- DummyReportService implementation
- ReportTemplate.xlsx sample file
- Ready for AS-Report/SpreadsheetGear integration
- Dependency injection for easy service replacement

#### Development Infrastructure
- Dependency injection configuration in MauiProgram.cs
- Service interfaces for testability
- IDbContextFactory for thread-safe database access
- Async/await patterns throughout
- Proper resource management with using statements

#### Documentation
- Comprehensive README.md with:
  - Feature overview
  - Setup instructions
  - Project structure
  - Database schema
  - Usage guide
  - Troubleshooting
- BUILD.md with detailed build instructions
- LICENSE file with third-party licenses
- Code comments for key components

#### Resources
- App icon and splash screen (SVG)
- Custom XAML styles (Colors.xaml, Styles.xaml)
- Bootstrap CSS framework
- Open Iconic icon font
- Custom CSS for Blazor components

### Technical Details

#### NuGet Packages
- Microsoft.Maui.Controls 8.0.90
- Microsoft.AspNetCore.Components.WebView.Maui 8.0.90
- Microsoft.EntityFrameworkCore.Sqlite 8.0.10
- Microsoft.EntityFrameworkCore.Design 8.0.10
- EPPlus 7.5.1

#### Target Framework
- net8.0-windows10.0.19041.0

#### Platform Support
- Windows 10 version 1809 or later
- Windows 11

### Design Principles

- **Separation of Concerns**: Clear separation between UI, business logic, and data access
- **Dependency Injection**: All services registered and injectable
- **Interface-based Design**: Services defined by interfaces for testability and flexibility
- **Async by Default**: All I/O operations use async/await
- **Resource Safety**: Proper disposal of resources (DbContext, file streams)
- **Extensibility**: Easy to replace components (grid, report service, Excel reader)

### Future Considerations

- Can be extended to web with minimal changes (using same EF Core code)
- Report service can be replaced with actual implementation
- Standard HTML tables can be replaced with advanced grid components
- Excel definition system can be extended for dynamic schema generation
- Authentication and authorization can be added
- Unit tests can be added using xUnit/NUnit

## Notes

This is the initial release providing a complete, working template for MAUI + Blazor Hybrid applications on Windows. All acceptance criteria from the original requirements have been met:

✅ Builds and runs on Windows
✅ Creates SQLite DB on first run
✅ Categories/Items CRUD operations
✅ Category combobox references table
✅ DataModel.xlsx read and displayed
✅ Export creates ZIP, Import restores
✅ Report page shows template path
✅ Comprehensive documentation
