namespace MauiBlazorApp.Services;

public interface IExcelDefinitionService
{
    Task<string> ReadAndValidateDefinitionAsync();
    Task<List<TableDefinition>> GetTableDefinitionsAsync();
}

public class TableDefinition
{
    public string TableName { get; set; } = string.Empty;
    public List<ColumnDefinition> Columns { get; set; } = new();
}

public class ColumnDefinition
{
    public string ColumnName { get; set; } = string.Empty;
    public string DataType { get; set; } = string.Empty;
    public bool IsRequired { get; set; }
    public int? MaxLength { get; set; }
}
