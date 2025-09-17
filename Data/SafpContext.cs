using Microsoft.EntityFrameworkCore;

public class SafpContext : DbContext
{
    public SafpContext(DbContextOptions<SafpContext> options) : base(options) { }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Provider> Providers { get; set; }
    public DbSet<User> Users { get; set; }
}