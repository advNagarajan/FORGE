using Microsoft.EntityFrameworkCore;
using FORGE.Shared.Models;

namespace FORGE.Infrastructure.Data;

public class ForgeDbContext: DbContext
{
    public ForgeDbContext(DbContextOptions<ForgeDbContext> options)
     : base(options) { }

    public DbSet<User> Users { get; set; }
}