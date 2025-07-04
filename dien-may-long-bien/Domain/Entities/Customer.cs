using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class Customer : BaseEntity
{
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public string Address { get; set; } = string.Empty;

    // Navigation properties
    public ICollection<CustomerEditHistory> EditHistories { get; set; } = [];
    public ICollection<Order> Orders { get; set; } = [];
    public ICollection<InstallmentPlan> InstallmentPlans { get; set; } = [];
}
