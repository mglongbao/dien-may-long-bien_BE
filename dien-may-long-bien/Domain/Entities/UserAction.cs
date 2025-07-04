using System.ComponentModel.DataAnnotations.Schema;
using DienMayLongBien.Domain.Primitives;

namespace DienMayLongBien.Domain.Entities;

public class UserAction : BaseEntity
{
    public Guid UserId { get; set; }
    public required string ActionType { get; set; } // e.g., "Create", "Update", "Delete"
    public required string EntityType { get; set; } // e.g., "Customer", "Order"
    public required string ActionDetails { get; set; } // JSON or string representation of the action details

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = null!;
}
