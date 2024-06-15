using System.ComponentModel.DataAnnotations;

namespace DevIO.Api.ViewModels;

public class ProductViewModel
{
    [Required]
    public Guid SupplierId { get; set; }

    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string? Name { get; set; }

    [Required]
    [StringLength(300, MinimumLength = 2)]
    public string? Description { get; set; }

    [Required]
    public decimal Value { get; set; }
}
