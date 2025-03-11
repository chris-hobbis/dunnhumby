using Dunnhumby.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Dunnhumby.WebAPI.Services;

public interface IProductCategoryService
{
    Task<ICollection<ProductCategoryModel>> GetAsync();
    Task<ICollection<ChartDataModel>> GetStockQuantityByCategoryAsync();
}

public class ProductCategoryService(ProductsDbContext dbContext) : BaseService(dbContext), IProductCategoryService
{
    public async Task<ICollection<ProductCategoryModel>> GetAsync()
    {
        var result = await Db.ProductCategories.AsNoTracking()
            .Select(x => new ProductCategoryModel()
            {
                Id = x.Id, 
                Name = x.Name
            }).ToListAsync();
        return result;
    }

    public async Task<ICollection<ChartDataModel>> GetStockQuantityByCategoryAsync()
    {
        var result = await Db.ProductCategories.AsNoTracking()
            .Select(x => new ChartDataModel()
            {
                Label = x.Name, 
                Qty = x.Products.Count
            }).ToListAsync();
        
        return result;
    }
}