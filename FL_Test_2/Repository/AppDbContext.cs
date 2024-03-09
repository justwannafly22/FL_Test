using FL_Test_2.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace FL_Test_2.Repository;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("AppDB");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ToDo: Seed the data.
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TagToUser> TagsToUsers { get; set; }
}
