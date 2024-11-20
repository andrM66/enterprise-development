using Microsoft.EntityFrameworkCore;
using BikeRent.Domain.Entities;

namespace BikeRent.Domain.Context;

public class BikeRentDbContext(DbContextOptions<BikeRentDbContext> options) : DbContext(options)
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<BikeType> BikeTypes{ get; set; }
    public DbSet<Bike> Bikes { get; set; }
    public DbSet<Rent> Rents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<BikeType>().HasData(
            new BikeType { Id = 1, Name = "Sport", Price = 100},
            new BikeType { Id = 2, Name = "Mountain", Price = 150},
            new BikeType { Id = 3, Name = "Walking", Price = 50}
            );
        modelBuilder.Entity<BikeType>()
            .HasMany<Bike>()
            .WithOne()
            .HasForeignKey(b => b.TypeId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Bike>()
            .HasOne<BikeType>()
            .WithMany();
        modelBuilder.Entity<Bike>()
            .HasMany<Rent>()
            .WithOne()
            .HasForeignKey(r => r.BikeId);

        modelBuilder.Entity<Client>()
            .HasMany<Rent>()
            .WithOne()
            .HasForeignKey(r => r.ClientId);

        modelBuilder.Entity<Rent>()
            .HasOne<Bike>()
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Rent>()
            .HasOne<Client>()
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);          
    }
}

