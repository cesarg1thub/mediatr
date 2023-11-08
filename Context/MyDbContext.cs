using mediatr_consoleapp1.Entities;
using Microsoft.EntityFrameworkCore;

namespace mediatr_consoleapp1.Context;

public class MyDbContext: DbContext, IMyDbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Site> Sites { get; set; } = null!;

    public async Task<int> SaveToDbAsync(CancellationToken cancellationToken = default)
    {
        return await SaveChangesAsync(cancellationToken);
    }
}
