using OfficeOpenXml;

namespace MauiBlazorApp.Services;

public class ExcelDefinitionService : IExcelDefinitionService
{
    private readonly string _definitionPath;

    public ExcelDefinitionService()
    {
        // DataModel.xlsx path in Resources/Raw folder
        _definitionPath = Path.Combine(AppContext.BaseDirectory, "DataModel.xlsx");
        
        // Set EPPlus license context (for non-commercial use)
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }

    public async Task<string> ReadAndValidateDefinitionAsync()
    {
        if (!File.Exists(_definitionPath))
        {
            return $"ERROR: DataModel.xlsx not found at {_definitionPath}";
        }

        try
        {
            var tables = await GetTableDefinitionsAsync();
            var result = $"DataModel.xlsx loaded successfully from {_definitionPath}\n\n";
            result += $"Found {tables.Count} table(s):\n";

            foreach (var table in tables)
            {
                result += $"\nTable: {table.TableName}\n";
                result += $"  Columns ({table.Columns.Count}):\n";
                foreach (var col in table.Columns)
                {
                    result += $"    - {col.ColumnName} ({col.DataType})";
                    if (col.IsRequired) result += " [Required]";
                    if (col.MaxLength.HasValue) result += $" [MaxLength: {col.MaxLength}]";
                    result += "\n";
                }
            }

            return result;
        }
        catch (Exception ex)
        {
            return $"ERROR reading DataModel.xlsx: {ex.Message}";
        }
    }

    public async Task<List<TableDefinition>> GetTableDefinitionsAsync()
    {
        var tables = new List<TableDefinition>();

        if (!File.Exists(_definitionPath))
        {
            return tables;
        }

        await Task.Run(() =>
        {
            using var package = new ExcelPackage(new FileInfo(_definitionPath));
            
            // Read Tables sheet
            var tablesSheet = package.Workbook.Worksheets["Tables"];
            if (tablesSheet != null)
            {
                // Assuming format: TableName in column A, starting from row 2
                for (int row = 2; row <= tablesSheet.Dimension?.End.Row; row++)
                {
                    var tableName = tablesSheet.Cells[row, 1].Text;
                    if (!string.IsNullOrWhiteSpace(tableName))
                    {
                        tables.Add(new TableDefinition { TableName = tableName });
                    }
                }
            }

            // Read Columns sheet
            var columnsSheet = package.Workbook.Worksheets["Columns"];
            if (columnsSheet != null)
            {
                // Assuming format: TableName, ColumnName, DataType, IsRequired, MaxLength
                for (int row = 2; row <= columnsSheet.Dimension?.End.Row; row++)
                {
                    var tableName = columnsSheet.Cells[row, 1].Text;
                    var columnName = columnsSheet.Cells[row, 2].Text;
                    var dataType = columnsSheet.Cells[row, 3].Text;
                    var isRequired = columnsSheet.Cells[row, 4].Text.ToLower() == "true" || columnsSheet.Cells[row, 4].Text == "1";
                    var maxLengthText = columnsSheet.Cells[row, 5].Text;

                    if (!string.IsNullOrWhiteSpace(tableName) && !string.IsNullOrWhiteSpace(columnName))
                    {
                        var table = tables.FirstOrDefault(t => t.TableName == tableName);
                        if (table != null)
                        {
                            table.Columns.Add(new ColumnDefinition
                            {
                                ColumnName = columnName,
                                DataType = dataType,
                                IsRequired = isRequired,
                                MaxLength = int.TryParse(maxLengthText, out var maxLen) ? maxLen : null
                            });
                        }
                    }
                }
            }
        });

        return tables;
    }
}
