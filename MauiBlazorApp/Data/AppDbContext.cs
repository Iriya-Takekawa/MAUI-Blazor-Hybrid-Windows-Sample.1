using Microsoft.EntityFrameworkCore;
using MauiBlazorApp.Models;

namespace MauiBlazorApp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.HasIndex(e => e.Code).IsUnique();
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Code).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
            entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            entity.Property(e => e.Note).HasMaxLength(500);
            entity.HasIndex(e => e.Code).IsUnique();

            entity.HasOne(e => e.Category)
                .WithMany(c => c.Items)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // Seed initial data
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Code = "CAT001", Name = "Electronics" },
            new Category { Id = 2, Code = "CAT002", Name = "Books" },
            new Category { Id = 3, Code = "CAT003", Name = "Office Supplies" }
        );

        modelBuilder.Entity<Item>().HasData(
            new Item { Id = 1, Code = "ITEM001", Name = "Laptop", CategoryId = 1, Amount = 1200.00m, Note = "High-performance laptop" },
            new Item { Id = 2, Code = "ITEM002", Name = "Programming Book", CategoryId = 2, Amount = 45.99m, Note = "C# programming guide" },
            new Item { Id = 3, Code = "ITEM003", Name = "Notebook", CategoryId = 3, Amount = 5.50m, Note = "A4 ruled notebook" }
        );
    }
}
