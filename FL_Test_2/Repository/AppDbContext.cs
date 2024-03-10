using FL_Test_2.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace FL_Test_2.Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { UserId = new Guid("0afa834e-ce99-4613-ac2c-c5b90268bc16"), Domain = "IT", Name = "Igor" },
            new User { UserId = new Guid("94ece4bb-8d83-40a2-b160-f99aca926c63"), Domain = "Energy", Name = "Egor" },
            new User { UserId = new Guid("89ec9bb3-5d69-4d59-9ab8-6397d01dd924"), Domain = "IT", Name = "Andrew" },
            new User { UserId = new Guid("489dc64f-7f85-4c29-865a-d0da398580bb"), Domain = "Finance", Name = "Alexey" },
            new User { UserId = new Guid("9b034c19-6053-421a-9718-ec726491a3f0"), Domain = "Energy", Name = "Dima" },
            new User { UserId = new Guid("a4c4bd5e-1199-438e-bd3e-ee704bd91ee8"), Domain = "IT", Name = "Kesha" }
        );

        modelBuilder.Entity<Tag>().HasData(
            new Tag { TagId = new Guid("3786a26c-7236-4f89-95cc-554525aa8249"), Domain = "IT", Value = "FirstTag" },
            new Tag { TagId = new Guid("fbed4178-2a2e-47b5-a3ed-2fa3e3c03d32"), Domain = "Energy", Value = "SecondTag" },
            new Tag { TagId = new Guid("d0a01a5f-d484-4ee6-9dd8-d2f5072a1ec4"), Domain = "IT", Value = "ThirdTag" },
            new Tag { TagId = new Guid("55cf219a-2c88-4b9f-b1d4-5463727eb75e"), Domain = "Finance", Value = "FouthTag" }
        );

        modelBuilder.Entity<TagToUser>().HasData(
            new TagToUser { TagId = new Guid("3786a26c-7236-4f89-95cc-554525aa8249"), UserId = new Guid("0afa834e-ce99-4613-ac2c-c5b90268bc16"), EntityId = new Guid("c7f4f7bd-d114-407c-974b-81d4cc7ae2d6") },
            new TagToUser { TagId = new Guid("fbed4178-2a2e-47b5-a3ed-2fa3e3c03d32"), UserId = new Guid("94ece4bb-8d83-40a2-b160-f99aca926c63"), EntityId = new Guid("4e2a3f8a-d8f7-4840-b050-c90afe731d2c") },
            new TagToUser { TagId = new Guid("d0a01a5f-d484-4ee6-9dd8-d2f5072a1ec4"), UserId = new Guid("89ec9bb3-5d69-4d59-9ab8-6397d01dd924"), EntityId = new Guid("e8a9680e-9587-4a65-a661-4841d83f347e") },
            new TagToUser { TagId = new Guid("55cf219a-2c88-4b9f-b1d4-5463727eb75e"), UserId = new Guid("489dc64f-7f85-4c29-865a-d0da398580bb"), EntityId = new Guid("fbafc82c-4032-4813-9632-3da2ebf91efc") },
            new TagToUser { TagId = new Guid("d0a01a5f-d484-4ee6-9dd8-d2f5072a1ec4"), UserId = new Guid("0afa834e-ce99-4613-ac2c-c5b90268bc16"), EntityId = new Guid("a8cec4d6-869e-4c8a-b699-8880e471fdee") },
            new TagToUser { TagId = new Guid("55cf219a-2c88-4b9f-b1d4-5463727eb75e"), UserId = new Guid("489dc64f-7f85-4c29-865a-d0da398580bb"), EntityId = new Guid("1bda44d8-aff6-4841-85cd-23411687ddf9") },
            new TagToUser { TagId = new Guid("d0a01a5f-d484-4ee6-9dd8-d2f5072a1ec4"), UserId = new Guid("89ec9bb3-5d69-4d59-9ab8-6397d01dd924"), EntityId = new Guid("8789a7d5-7f04-4132-8966-b885c0586648") }
        );
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<TagToUser> TagsToUsers { get; set; }
}
