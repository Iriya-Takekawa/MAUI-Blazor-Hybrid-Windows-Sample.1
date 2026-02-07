namespace MauiBlazorApp.Services;

public interface IDataExportImportService
{
    Task<string> ExportDatabaseAsync(string exportPath);
    Task<string> ImportDatabaseAsync(string importPath);
    string GetDefaultExportPath();
}
