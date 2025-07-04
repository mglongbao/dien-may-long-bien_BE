using System.ComponentModel.DataAnnotations.Schema;
using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class ImportHistory : BaseEntity
{
    public Guid ProductId { get; set; }
    public Guid SupplierId { get; set; }
    public Guid ImportByUserId { get; set; }

    public required int Quantity { get; set; }
    public required decimal ImportPrice { get; set; }
    public required decimal TotalPrice { get; set; }

    // Navigation properties
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;

    [ForeignKey(nameof(SupplierId))]
    public Supplier Supplier { get; set; } = null!;
}
