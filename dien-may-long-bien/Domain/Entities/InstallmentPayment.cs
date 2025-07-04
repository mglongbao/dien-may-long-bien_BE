using System.ComponentModel.DataAnnotations.Schema;
using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class InstallmentPayment : BaseEntity
{
    public Guid InstallmentPlanId { get; set; }

    public required decimal PaymentAmount { get; set; }

    // Navigation properties
    [ForeignKey(nameof(InstallmentPlanId))]
    public InstallmentPlan InstallmentPlan { get; set; } = null!;
}
