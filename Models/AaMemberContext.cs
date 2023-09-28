using Microsoft.EntityFrameworkCore;

namespace AanniversariesApi.Models;

public class AaMemberContext : DbContext
{
    public AaMemberContext(DbContextOptions<AaMemberContext> options)
        : base(options)
    {
    }

    public DbSet<AaMember> AaMembers { get; set; } = null!;
}