using System.ComponentModel.DataAnnotations.Schema;
using DienMayLongBien.Domain.Enum;
using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class Order : BaseEntity
{
    public Guid CustomerId { get; set; }
    public Guid ProcessByUserId { get; set; }

    public required decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal FinalAmount => TotalAmount - DiscountAmount;
    public required PaymentMethod PaymentMethod { get; set; } = PaymentMethod.Cash;
    public required PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Ongoing;

    // Navigation properties
    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; } = null!;

    [ForeignKey(nameof(ProcessByUserId))]
    public User ProcessByUser { get; set; } = null!;
}
