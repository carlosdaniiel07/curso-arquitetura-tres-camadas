namespace DevIO.Business.Models;

public class Supplier : Entity
{
    public string? Name { get; set; }
    public string? Document { get; set; }
    public SupplierKind Kind { get; set; }
    public Address? Address { get; set; }
    public bool IsEnabled { get; set; }
    public IEnumerable<Product>? Products { get; set; }
}
