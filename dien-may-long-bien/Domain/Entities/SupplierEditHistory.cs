using System.ComponentModel.DataAnnotations.Schema;
using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class SupplierEditHistory : BaseEntity
{
    public Guid SupplierId { get; set; }

    public required string SupplierName { get; set; }
    public string ContactName { get; set; } = string.Empty;
    public required string Phone { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    // Navigation properties
    [ForeignKey(nameof(SupplierId))]
    public Supplier Supplier { get; set; } = null!;
}
