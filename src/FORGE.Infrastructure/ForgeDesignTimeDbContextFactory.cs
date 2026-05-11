using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FORGE.Infrastructure.Data;

namespace FORGE.Infrastructure;

public class ForgeDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ForgeDbContext>
{
    public ForgeDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ForgeDbContext>();
        optionsBuilder.UseSqlite("Data Source=../FORGE.API/forge.db");
        return new ForgeDbContext(optionsBuilder.Options);
    }
}
