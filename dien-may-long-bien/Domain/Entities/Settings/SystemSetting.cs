using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities.Settings;

public class SystemSetting : BaseEntity
{
    public Guid StoreSettingId { get; set; }

    public required int LowStockThreshold { get; set; } = 5;
    public bool EnableBackup { get; set; } = true;
}
