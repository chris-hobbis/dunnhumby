using Dunnhumby.WebAPI.Data;
using Dunnhumby.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dunnhumby.WebAPI.Controllers;

/// <summary>
/// Product endpoints.
/// </summary>
/// <param name="productService"></param>
[ApiController]
[Route("[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    /// <summary>
    /// Provides a collection of products.
    /// </summary>
    /// <returns>A collection of products with related categories</returns>
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var products = await productService.GetAsync();
        return Ok(products);
    }

    /// <summary>
    /// Provides a product by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The product</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(string id)
    {
        var product = await productService.GetByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        
        return Ok(product);
    }
    
    /// <summary>
    /// Creates a product.
    /// </summary>
    /// <param name="product"></param>
    /// <returns>The product that has been created</returns>
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductInputModel product)
    {
        var item = await productService.CreateAsync(product);
        return CreatedAtAction(nameof(GetProduct), new { id = item.Id }, item);
    }
    
    /// <summary>
    /// Updates the product by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="product"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(string id, [FromBody] ProductInputModel product)
    {
        await productService.UpdateAsync(product);
        return NoContent();
    }
}