namespace FORGE.Shared.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public ICollection<Session> CreatedSessions { get; set; } = new List<Session>();
    public ICollection<SessionUser> SessionUsers { get; set; } = new List<SessionUser>();
    public ICollection<ExecutionRecord> ExecutionRecords { get; set; } = new List<ExecutionRecord>();
}