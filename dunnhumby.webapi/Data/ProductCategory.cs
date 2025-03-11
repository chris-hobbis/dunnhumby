namespace Dunnhumby.WebAPI.Data;

public class ProductCategory
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public virtual ICollection<Product> Products { get; set; } = Enumerable.Empty<Product>().ToList();
}