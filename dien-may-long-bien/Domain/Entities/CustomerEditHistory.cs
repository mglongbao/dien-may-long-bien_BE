using System.ComponentModel.DataAnnotations.Schema;
using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class CustomerEditHistory : BaseEntity
{
    public Guid CustomerId { get; set; }

    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public string Address { get; set; } = string.Empty;

    // Navigation properties
    [ForeignKey(nameof(CustomerId))]
    public Customer Customer { get; set; } = null!;
}
