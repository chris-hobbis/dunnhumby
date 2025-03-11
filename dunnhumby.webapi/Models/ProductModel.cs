namespace Dunnhumby.WebAPI.Data;

public class ProductModel
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string SKU { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public DateTime DateAdded { get; set; }
    public string DateAddedFormatted => DateAdded.ToShortDateString();
    public string CategoryId { get; set; }
    public ProductCategoryModel Category { get; set; }
}