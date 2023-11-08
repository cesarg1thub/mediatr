using mediatr_consoleapp1.Entities;
using Microsoft.EntityFrameworkCore;

namespace mediatr_consoleapp1.Context;

public interface IMyDbContext
{
    DbSet<Site> Sites { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
