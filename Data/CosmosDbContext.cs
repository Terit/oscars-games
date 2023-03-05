using Microsoft.EntityFrameworkCore;

namespace oscars_games.Data;

public class CosmosDbContext : DbContext
{
    public CosmosDbContext(DbContextOptions<CosmosDbContext> options)
        : base(options) { }

    public DbSet<CategorySelection> UserSelections { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<CategorySelection>()
            .ToContainer("UserSelections")
            .HasNoDiscriminator()
            .HasPartitionKey(x => x.Uid);

        base.OnModelCreating(modelBuilder);
    }
}
