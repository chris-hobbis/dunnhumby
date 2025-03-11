using System.ComponentModel.DataAnnotations.Schema;

namespace Dunnhumby.WebAPI.Data;

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string SKU { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime DateAdded { get; set; }
    
    [ForeignKey("CategoryId")]
    public string CategoryId { get; set; }
    public virtual ProductCategory Category { get; set; }
}