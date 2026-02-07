namespace MauiBlazorApp.Services;

public class DummyReportService : IReportService
{
    private readonly string _templatePath;

    public DummyReportService()
    {
        // Template path in Resources/Raw folder
        _templatePath = Path.Combine(AppContext.BaseDirectory, "ReportTemplate.xlsx");
    }

    public string GetReportTemplatePath()
    {
        return _templatePath;
    }

    public bool ValidateReportTemplate()
    {
        return File.Exists(_templatePath);
    }
}
