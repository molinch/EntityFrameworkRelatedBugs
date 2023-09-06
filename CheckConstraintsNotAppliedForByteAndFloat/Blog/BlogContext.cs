using Microsoft.EntityFrameworkCore;

namespace Blog;

public class BlogContext : DbContext
{
    public DbSet<Post> Posts { set; get; }

    private const string connectionString = @"Server=localhost,1434;Database=Blog;User Id=sa;Password=Password@123;TrustServerCertificate=true";

    public BlogContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseValidationCheckConstraints();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.PostType).HasConversion<string>();
            entity.Property(b => b.SomeIntFieldWithRange);
            entity.Property(b => b.SomeByteFieldWithRange);
            entity.Property(b => b.SomeFloatFieldWithRange);
        });
    }
}