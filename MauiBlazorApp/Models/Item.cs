namespace MauiBlazorApp.Models;

public class Item
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public decimal Amount { get; set; }
    public string Note { get; set; } = string.Empty;

    public Category? Category { get; set; }
}
