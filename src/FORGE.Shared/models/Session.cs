namespace FORGE.Shared.Models;

public class Session
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid CreatedByUserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public User CreatedByUser { get; set; } = null!;
    public ICollection<SessionUser> SessionUsers { get; set; } = new List<SessionUser>();
    public ICollection<ExecutionRecord> ExecutionRecords { get; set; } = new List<ExecutionRecord>();
}
