namespace Dunnhumby.WebAPI.Data;

public class ProductInputModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string SKU { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string CategoryId { get; set; }
}