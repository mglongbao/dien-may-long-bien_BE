namespace DienMayLongBien.Domain.Primitives;

public class BaseEntity
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public DateTimeOffset? UpdatedAt { get; set; } = null!;
    public DateTimeOffset? DeletedAt { get; set; } = null!;
    public Guid? UpdatedBy { get; set; }
    public Guid? DeletedBy { get; set; }
    public bool IsDeleted { get; set; }

    public void Update(Guid id)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = id;
    }

    public void Delete(Guid id)
    {
        UpdatedAt = DateTime.UtcNow;
        DeletedAt = DateTime.UtcNow;
        IsDeleted = true;
        DeletedBy = id;
    }

    public void Restore()
    {
        UpdatedAt = DateTime.UtcNow;
        DeletedAt = null;
        IsDeleted = false;
        DeletedBy = null;
    }
}
