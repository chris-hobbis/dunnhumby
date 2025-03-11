using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Dunnhumby.WebAPI.Data;

public class ProductsDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var databaseFileName = "Products.db";
        //var installDatabasePath = Path.Combine(AppContext.BaseDirectory, "Data", databaseFileName);
        var localDatabasePath = Path.Combine(AppContext.BaseDirectory, "Data", databaseFileName);

        // if (!File.Exists(localDatabasePath))
        // {
        //     try
        //     {
        //         File.Copy(installDatabasePath, localDatabasePath);
        //     }
        //     catch (Exception ex)
        //     {
        //         // Handle the exception (e.g., log an error)
        //         Debug.WriteLine($"Error copying database: {ex.Message}");
        //     }
        // }

        optionsBuilder.UseSqlite($"Data Source={localDatabasePath}");
    }
}