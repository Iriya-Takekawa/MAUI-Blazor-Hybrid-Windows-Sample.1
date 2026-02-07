# MAUI Blazor Hybrid Windows Sample - Architecture

## System Architecture Overview

```
┌─────────────────────────────────────────────────────────────────┐
│                         MAUI Application                         │
│  ┌────────────────────────────────────────────────────────────┐ │
│  │                    BlazorWebView                           │ │
│  │  ┌──────────────────────────────────────────────────────┐ │ │
│  │  │              Blazor Components (Razor)               │ │ │
│  │  │  ┌────────────┬────────────┬────────────┬──────────┐│ │ │
│  │  │  │   Home     │ Categories │   Items    │  Export  ││ │ │
│  │  │  │   Page     │   Page     │   Page     │  Import  ││ │ │
│  │  │  └────────────┴────────────┴────────────┴──────────┘│ │ │
│  │  │  ┌────────────┬────────────┐                        │ │ │
│  │  │  │  Report    │ Definition │                        │ │ │
│  │  │  │   Page     │    Page    │                        │ │ │
│  │  │  └────────────┴────────────┘                        │ │ │
│  │  └──────────────────────────────────────────────────────┘ │ │
│  └────────────────────────────────────────────────────────────┘ │
│                                                                   │
│  ┌────────────────────────────────────────────────────────────┐ │
│  │                    Service Layer (DI)                      │ │
│  │  ┌──────────────┬──────────────┬──────────────────────┐  │ │
│  │  │IReportService│IExcelDefSvc  │IDataExportImportSvc  │  │ │
│  │  │    (Dummy)   │  (EPPlus)    │      (Zip)           │  │ │
│  │  └──────────────┴──────────────┴──────────────────────┘  │ │
│  └────────────────────────────────────────────────────────────┘ │
│                                                                   │
│  ┌────────────────────────────────────────────────────────────┐ │
│  │              Data Access Layer (EF Core)                   │ │
│  │  ┌──────────────────────────────────────────────────────┐ │ │
│  │  │              AppDbContext                            │ │ │
│  │  │  ┌──────────────────┬──────────────────────────────┐│ │ │
│  │  │  │  DbSet<Category> │     DbSet<Item>              ││ │ │
│  │  │  └──────────────────┴──────────────────────────────┘│ │ │
│  │  └──────────────────────────────────────────────────────┘ │ │
│  │                          │                                  │ │
│  │                          ▼                                  │ │
│  │  ┌──────────────────────────────────────────────────────┐ │ │
│  │  │          SQLite Database (app.db)                    │ │ │
│  │  │  ┌────────────────┬──────────────────────────────┐  │ │ │
│  │  │  │   Categories   │          Items               │  │ │ │
│  │  │  │  - Id (PK)     │  - Id (PK)                   │  │ │ │
│  │  │  │  - Code        │  - Code                      │  │ │ │
│  │  │  │  - Name        │  - Name                      │  │ │ │
│  │  │  │                │  - CategoryId (FK)           │  │ │ │
│  │  │  │                │  - Amount                    │  │ │ │
│  │  │  │                │  - Note                      │  │ │ │
│  │  │  └────────────────┴──────────────────────────────┘  │ │ │
│  │  └──────────────────────────────────────────────────────┘ │ │
│  └────────────────────────────────────────────────────────────┘ │
└─────────────────────────────────────────────────────────────────┘

┌─────────────────────────────────────────────────────────────────┐
│                      External Resources                          │
│  ┌────────────────┬────────────────┬─────────────────────────┐  │
│  │ DataModel.xlsx │ReportTemplate  │  Export/Import Files    │  │
│  │ (Resources/Raw)│.xlsx           │  (Documents folder)     │  │
│  └────────────────┴────────────────┴─────────────────────────┘  │
└─────────────────────────────────────────────────────────────────┘
```

## Component Interaction Flow

### 1. Application Startup

```
MauiProgram.CreateMauiApp()
    │
    ├─> Register Services (DI)
    │   ├─> AddDbContext<AppDbContext>
    │   ├─> AddDbContextFactory<AppDbContext>
    │   ├─> AddSingleton<IReportService, DummyReportService>
    │   ├─> AddSingleton<IExcelDefinitionService, ExcelDefinitionService>
    │   └─> AddSingleton<IDataExportImportService, DataExportImportService>
    │
    └─> Initialize Database
        └─> AppDbContext.Database.EnsureCreated()
            └─> Create SQLite DB with seed data
```

### 2. CRUD Operations (Example: Adding an Item)

```
User clicks "Add New Item" in Items.razor
    │
    ├─> ShowAddForm() - Display form
    │
    └─> User fills form and clicks "Save"
        │
        └─> SaveItem()
            ├─> Create DbContext via IDbContextFactory
            ├─> context.Items.Add(newItem)
            ├─> context.SaveChangesAsync()
            └─> LoadData() - Refresh list
```

### 3. Export Database Flow

```
User clicks "Export Now" in ExportImport.razor
    │
    └─> ExportDatabase()
        ├─> IDataExportImportService.ExportDatabaseAsync()
        │   ├─> Read app.db file
        │   ├─> Create ZIP archive
        │   └─> Save to Documents/MauiBlazorApp_Exports/
        │
        └─> Display success message with file path
```

### 4. Import Database Flow

```
User enters ZIP path and clicks "Import Now"
    │
    └─> ImportDatabase()
        ├─> IDataExportImportService.ImportDatabaseAsync()
        │   ├─> Backup current app.db
        │   ├─> Extract app.db from ZIP
        │   └─> Replace current database
        │
        └─> Display success message (restart required)
```

### 5. Excel Definition Reading Flow

```
User navigates to Definition page
    │
    └─> OnInitializedAsync()
        └─> LoadDefinition()
            ├─> IExcelDefinitionService.ReadAndValidateDefinitionAsync()
            │   ├─> Open DataModel.xlsx with EPPlus
            │   ├─> Read "Tables" sheet
            │   ├─> Read "Columns" sheet
            │   └─> Format and validate data
            │
            └─> Display formatted result
```

## Data Flow Diagram

```
┌──────────┐         ┌──────────────┐         ┌────────────┐
│   User   │◄───────►│Blazor Pages  │◄───────►│  Services  │
└──────────┘         └──────────────┘         └────────────┘
                            │                         │
                            │                         │
                            ▼                         ▼
                     ┌──────────────┐         ┌────────────┐
                     │ Components   │         │   Models   │
                     │  (Razor)     │         │ (Entities) │
                     └──────────────┘         └────────────┘
                            │                         │
                            │                         │
                            ▼                         ▼
                     ┌──────────────────────────────────┐
                     │        AppDbContext             │
                     │      (Entity Framework)         │
                     └──────────────────────────────────┘
                                     │
                                     ▼
                     ┌──────────────────────────────────┐
                     │      SQLite Database (app.db)   │
                     └──────────────────────────────────┘
```

## Technology Stack

```
┌─────────────────────────────────────────────────────┐
│                  Presentation Layer                  │
│  ┌───────────────────────────────────────────────┐  │
│  │ Blazor Components (.razor)                    │  │
│  │ HTML + CSS (Bootstrap 5.3, Open Iconic)       │  │
│  └───────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────┘
                        │
┌─────────────────────────────────────────────────────┐
│                   Business Layer                     │
│  ┌───────────────────────────────────────────────┐  │
│  │ Services (C# Classes)                         │  │
│  │ - ReportService                               │  │
│  │ - ExcelDefinitionService (EPPlus)             │  │
│  │ - DataExportImportService (System.IO.Zip)    │  │
│  └───────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────┘
                        │
┌─────────────────────────────────────────────────────┐
│                    Data Layer                        │
│  ┌───────────────────────────────────────────────┐  │
│  │ Entity Framework Core                         │  │
│  │ - AppDbContext                                │  │
│  │ - Models (Category, Item)                     │  │
│  │ - SQLite Provider                             │  │
│  └───────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────┘
                        │
┌─────────────────────────────────────────────────────┐
│                  Infrastructure                      │
│  ┌───────────────────────────────────────────────┐  │
│  │ .NET MAUI Framework                           │  │
│  │ - BlazorWebView                               │  │
│  │ - FileSystem API                              │  │
│  │ - Platform Services                           │  │
│  └───────────────────────────────────────────────┘  │
└─────────────────────────────────────────────────────┘
```

## Security Considerations

```
┌────────────────────────────────────────────────┐
│              Security Layers                   │
├────────────────────────────────────────────────┤
│ 1. File System Access                          │
│    - App sandboxed in AppDataDirectory         │
│    - User documents for exports only           │
├────────────────────────────────────────────────┤
│ 2. Database Access                             │
│    - Local SQLite only                         │
│    - No network exposure                       │
│    - EF Core parameterized queries             │
├────────────────────────────────────────────────┤
│ 3. Excel File Processing                       │
│    - EPPlus with NonCommercial license         │
│    - Read-only definition files                │
│    - Validation on import                      │
├────────────────────────────────────────────────┤
│ 4. Export/Import                               │
│    - ZIP compression only                      │
│    - No encryption (can be added)              │
│    - Backup before import                      │
└────────────────────────────────────────────────┘
```

## Extension Points

The architecture supports easy extension in these areas:

1. **Report Service**
   - Replace `DummyReportService` with actual implementation
   - Implement `IReportService` interface
   - Register in DI container

2. **Grid Components**
   - Replace `<table>` in Razor pages
   - Use Telerik, Syncfusion, or DevExpress
   - Maintain same data binding

3. **Database Provider**
   - Switch from SQLite to SQL Server
   - Change connection string in MauiProgram.cs
   - Update EF Core provider package

4. **Authentication**
   - Add authentication service
   - Implement in MauiProgram.cs
   - Add to relevant pages

5. **Excel Schema Processing**
   - Extend `ExcelDefinitionService`
   - Add dynamic entity generation
   - Implement schema migration

## Performance Considerations

```
┌──────────────────────────────────────────────┐
│          Performance Strategy                │
├──────────────────────────────────────────────┤
│ 1. Database                                  │
│    - IDbContextFactory for thread safety     │
│    - Async operations throughout             │
│    - Indexes on Code columns (unique)        │
│    - Include() for eager loading             │
├──────────────────────────────────────────────┤
│ 2. UI                                        │
│    - Virtualization for large lists (future) │
│    - Pagination support ready                │
│    - Async state updates                     │
├──────────────────────────────────────────────┤
│ 3. File Operations                           │
│    - Async file I/O                          │
│    - Stream processing for large files       │
│    - Proper disposal with using statements   │
└──────────────────────────────────────────────┘
```

This architecture provides a solid foundation for a production-ready MAUI Blazor Hybrid application with clear separation of concerns, extensibility, and maintainability.
