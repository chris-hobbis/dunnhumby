using Dunnhumby.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dunnhumby.WebAPI.Controllers;

/// <summary>
/// Chart data enpoints.
/// </summary>
/// <param name="productCategoryService"></param>
/// <param name="productService"></param>
[ApiController]
[Route("[controller]")]
public class ChartDataController(IProductCategoryService productCategoryService, IProductService productService) : ControllerBase
{
    /// <summary>
    /// Provides a stock count by category
    /// </summary>
    /// <returns>A collection of quantity counts per category</returns>
    [HttpGet("stockquantitybycategory")]
    public async Task<IActionResult> GetStockQuantityByCategory()
    {
        var items = await productCategoryService.GetStockQuantityByCategoryAsync();
        return Ok(items);
    }
    
    /// <summary>
    /// Provides counts of stock added by increments of time based values: last week, month and year
    /// </summary>
    /// <returns>A collection of stock counts added by time based increments</returns>
    [HttpGet("productsadded")]
    public async Task<IActionResult> GetProductsAdded()
    {
        var items = await productService.GetProductsAddedByTimeAsync();
        return Ok(items);
    }
}