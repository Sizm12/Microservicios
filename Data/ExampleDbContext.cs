using Microsoft.EntityFrameworkCore;

namespace ExampleDocker;

public class ExampleDbContext : DbContext
{
    public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
