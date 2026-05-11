namespace FORGE.Shared.Models;

public class SessionUser
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SessionId { get; set; }
    public Guid UserId { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public Session Session { get; set; } = null!;
    public User User { get; set; } = null!;
}
