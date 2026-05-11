using Microsoft.EntityFrameworkCore;
using FORGE.Shared.Models;

namespace FORGE.Infrastructure.Data;

public class ForgeDbContext: DbContext
{
    public ForgeDbContext(DbContextOptions<ForgeDbContext> options)
     : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<SessionUser> SessionUsers { get; set; }
    public DbSet<ExecutionRecord> ExecutionRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.CreatedByUser)
                .WithMany(u => u.CreatedSessions)
                .HasForeignKey(e => e.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.SessionUsers)
                .WithOne(su => su.Session)
                .HasForeignKey(su => su.SessionId);

            entity.HasMany(e => e.ExecutionRecords)
                .WithOne(er => er.Session)
                .HasForeignKey(er => er.SessionId);
        });

        modelBuilder.Entity<SessionUser>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => new { e.SessionId, e.UserId }).IsUnique();

            entity.HasOne(e => e.Session)
                .WithMany(s => s.SessionUsers)
                .HasForeignKey(e => e.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.User)
                .WithMany(u => u.SessionUsers)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ExecutionRecord>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Session)
                .WithMany(s => s.ExecutionRecords)
                .HasForeignKey(e => e.SessionId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.User)
                .WithMany(u => u.ExecutionRecords)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}