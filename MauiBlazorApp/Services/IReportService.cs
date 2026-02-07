namespace MauiBlazorApp.Services;

public interface IReportService
{
    string GetReportTemplatePath();
    bool ValidateReportTemplate();
}
