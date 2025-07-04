using System.ComponentModel.DataAnnotations.Schema;
using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class InstallmentPlan : BaseEntity
{
    public Guid OrderId { get; set; }
    public Guid CustomerId { get; set; }

    public required int TotalInstallments { get; set; }
    public required decimal AmountPerInstallment { get; set; }

    // Navigation properties
    [ForeignKey(nameof(OrderId))]
    public Order Order { get; set; } = null!;

    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; } = null!;

    public ICollection<InstallmentPayment> InstallmentPayments { get; set; } = [];
}
