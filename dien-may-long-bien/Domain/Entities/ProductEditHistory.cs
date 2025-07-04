using System.ComponentModel.DataAnnotations.Schema;
using DienMayLongBien.Domain.Enum;
using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class ProductEditHistory : BaseEntity
{
    public Guid ProductId { get; set; }
    public Guid BrandId { get; set; }
    public Guid CategoryId { get; set; }

    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public char BarCode { get; set; }
    public AvailabilityStatus AvailabilityStatus { get; set; } = AvailabilityStatus.InStock;
    public required int CurrentQuantity { get; set; }
    public int MinimumQuantity { get; set; }
    public required decimal ImportPrice { get; set; }
    public decimal RetailPrice { get; set; }
    public decimal WholesalePrice { get; set; }
    public string StorageLocation { get; set; } = string.Empty;

    // Navigation properties
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;

    [ForeignKey(nameof(BrandId))]
    public Brand Brand { get; set; } = null!;

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; } = null!;
}
