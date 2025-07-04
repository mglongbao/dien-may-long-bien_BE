using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class Supplier : BaseEntity
{
    public required string SupplierName { get; set; }
    public string ContactName { get; set; } = string.Empty;
    public required string Phone { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    // Navigation properties
    public ICollection<ImportHistory> ImportHistories { get; set; } = [];
    public ICollection<SupplierEditHistory> SupplierEditHistories { get; set; } = [];
}
