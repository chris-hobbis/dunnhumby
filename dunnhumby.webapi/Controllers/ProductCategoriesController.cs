using Dunnhumby.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dunnhumby.WebAPI.Controllers;

/// <summary>
/// Product category endpoints
/// </summary>
/// <param name="productCategoryService"></param>
[ApiController]
[Route("[controller]")]
public class ProductCategoriesController(IProductCategoryService productCategoryService) : ControllerBase
{
    /// <summary>
    /// Provides a collection categories
    /// </summary>
    /// <returns>Product category collection</returns>
    [HttpGet]
    public async Task<IActionResult> GetProductCategories()
    {
        var items = await productCategoryService.GetAsync();
        return Ok(items);
    }
}