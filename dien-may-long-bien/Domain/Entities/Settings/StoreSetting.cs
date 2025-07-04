using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities.Settings;

public class StoreSetting : BaseEntity
{
    public required string StoreName { get; set; }
    public required string StoreAddress { get; set; }
    public required string StorePhoneNumber { get; set; }
    public required string StoreEmail { get; set; }
    public string StoreLogoUrl { get; set; } = string.Empty;
    public string StoreDescription { get; set; } = string.Empty;

    // Navigation properties
    public ICollection<SystemSetting> SystemSettings { get; set; } = [];
}
