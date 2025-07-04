using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class Brand : BaseEntity
{
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    // Navigation properties
    public ICollection<Product> Products { get; set; } = [];
}
