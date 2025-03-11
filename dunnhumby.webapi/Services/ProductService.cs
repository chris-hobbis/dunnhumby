using Dunnhumby.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Dunnhumby.WebAPI.Services;

public interface IProductService
{
    Task<ICollection<ProductModel>> GetAsync();
    Task<ProductModel> GetByIdAsync(string id);
    Task<ProductModel> CreateAsync(ProductInputModel input);
    Task UpdateAsync(ProductInputModel input);
    Task DeleteAsync(string id);
    Task<ICollection<ChartDataModel>> GetProductsAddedByTimeAsync();
}

public class ProductService(ProductsDbContext dbContext) : BaseService(dbContext), IProductService
{
    public async Task<ICollection<ProductModel>> GetAsync()
    {
        var result = await Db.Products
            .AsNoTracking()
            .Select(x => new ProductModel()
            {
                Id = x.Id, 
                Name = x.Name,
                Price =  x.Price,
                Stock = x.Stock,
                DateAdded = x.DateAdded,
                Code =  x.Code,
                SKU = x.SKU,
                CategoryId = x.CategoryId,
                Category = new ProductCategoryModel()
                {
                    Id = x.Category.Id,
                    Name = x.Category.Name
                }
            }).ToListAsync();
        
        return result;
    }

    public async Task<ProductModel> GetByIdAsync(string id)
    {
        var result = await Db.Products.Where(x => x.Id == id)
            .AsNoTracking()
            .Select(x => new ProductModel()
            {
                Id = x.Id, 
                Name = x.Name,
                Price =  x.Price,
                Stock = x.Stock,
                DateAdded = x.DateAdded,
                Code =  x.Code,
                SKU = x.SKU,
                CategoryId = x.CategoryId,
                Category = new ProductCategoryModel()
                {
                    Id = x.Category.Id,
                    Name = x.Category.Name
                }
            }).FirstOrDefaultAsync();
        
        return result;
    }

    public async Task<ProductModel> CreateAsync(ProductInputModel input)
    {
        var product = new Product()
        {
            Id = Guid.NewGuid().ToString(),
            Name = input.Name,
            Price = input.Price,
            Stock = input.Stock,
            CategoryId = input.CategoryId,
            DateAdded = DateTime.Now,
            Code = input.Code,
            SKU = input.SKU
        };
        
        Db.Products.Add(product);
        await Db.SaveChangesAsync();
        return await GetByIdAsync(product.Id);
    }

    public async Task UpdateAsync(ProductInputModel input)
    {
        var item = await Db.Products.FirstOrDefaultAsync(x => x.Id == input.Id);
        if (item != null)
        {
            item.Name = input.Name;
            item.Price = input.Price;
            item.Stock = input.Stock;
            item.Code =  input.Code;
            item.SKU = input.SKU;
            item.CategoryId = input.CategoryId;
            await Db.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(string id)
    {
        var item = await Db.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (item != null)
        {
            Db.Products.Remove(item);
            await Db.SaveChangesAsync();
        }
    }

    public async Task<ICollection<ChartDataModel>> GetProductsAddedByTimeAsync()
    {
        var result = new List<ChartDataModel>();
        var thisWeek = await Db.Products.CountAsync(x => x.DateAdded >= DateTime.Today.AddDays(-7));
        var thisMonth = await Db.Products.CountAsync(x => x.DateAdded >= DateTime.Today.AddMonths(-1));
        var thisYear = await Db.Products.CountAsync(x => x.DateAdded >= DateTime.Today.AddYears(-1));
        
        result.Add(new ChartDataModel() { Label = "This week", Qty =  thisWeek });
        result.Add(new ChartDataModel() { Label = "This month", Qty =  thisMonth });
        result.Add(new ChartDataModel() { Label = "This year", Qty =  thisYear });

        return result;
    }
}