using ExampleDocker.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleDocker.Data;

public class ExampleDbContext : DbContext
{
    public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options) { }

    public DbSet<UserEntities> Users { get; set; }
}
