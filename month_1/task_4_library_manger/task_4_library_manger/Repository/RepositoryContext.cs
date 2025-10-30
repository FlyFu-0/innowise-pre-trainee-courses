using Microsoft.EntityFrameworkCore;
using task_4_library_manger.Entities.Models;
using task_4_library_manger.Models;
using task_4_library_manger.Repository.Configuration;

namespace task_4_library_manger.Repository;

public class RepositoryContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
    }

    public DbSet<Book>? Books { get; set; }
    public DbSet<Author>? Authors { get; set; }

}
