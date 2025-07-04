using System.ComponentModel.DataAnnotations.Schema;
using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class ProductOrder : BaseEntity
{
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }

    public required int Quantity { get; set; }
    public required decimal PriceAtPurchase { get; set; }
    public decimal TotalPrice => PriceAtPurchase * Quantity;

    // Navigation properties
    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;

    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;
}
