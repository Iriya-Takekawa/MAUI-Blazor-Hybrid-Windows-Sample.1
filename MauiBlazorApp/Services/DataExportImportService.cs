using System.IO.Compression;

namespace MauiBlazorApp.Services;

public class DataExportImportService : IDataExportImportService
{
    private readonly string _dbPath;

    public DataExportImportService()
    {
        _dbPath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
    }

    public string GetDefaultExportPath()
    {
        // Use Documents folder for exports
        var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var exportFolder = Path.Combine(documentsPath, "MauiBlazorApp_Exports");
        Directory.CreateDirectory(exportFolder);
        return exportFolder;
    }

    public async Task<string> ExportDatabaseAsync(string exportPath)
    {
        try
        {
            if (!File.Exists(_dbPath))
            {
                return "ERROR: Database file not found";
            }

            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var zipFileName = $"database_export_{timestamp}.zip";
            var zipPath = Path.Combine(exportPath, zipFileName);

            // Create zip file with the database
            using (var archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(_dbPath, "app.db");
            }

            return $"SUCCESS: Database exported to {zipPath}";
        }
        catch (Exception ex)
        {
            return $"ERROR: {ex.Message}";
        }
    }

    public async Task<string> ImportDatabaseAsync(string importPath)
    {
        try
        {
            if (!File.Exists(importPath))
            {
                return "ERROR: Import file not found";
            }

            // Create backup of current database
            if (File.Exists(_dbPath))
            {
                var backupPath = $"{_dbPath}.backup_{DateTime.Now:yyyyMMdd_HHmmss}";
                File.Copy(_dbPath, backupPath, true);
            }

            // Extract database from zip
            using (var archive = ZipFile.OpenRead(importPath))
            {
                var dbEntry = archive.GetEntry("app.db");
                if (dbEntry == null)
                {
                    return "ERROR: Database file not found in zip archive";
                }

                dbEntry.ExtractToFile(_dbPath, true);
            }

            return "SUCCESS: Database imported successfully. Please restart the application to see changes.";
        }
        catch (Exception ex)
        {
            return $"ERROR: {ex.Message}";
        }
    }
}
