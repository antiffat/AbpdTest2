using Abpd_Test2.Models;
using Microsoft.EntityFrameworkCore;

namespace Abpd_Test2.Helpers;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<CarManufacturer> CarManufacturers { get; set; }
    public DbSet<Competition> Competitions { get; set; }
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<DriverCompetition> DriverCompetitions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<CarManufacturer>()
            .HasKey(cm => cm.Id);
        
        modelBuilder.Entity<CarManufacturer>()
            .HasIndex(cm => cm.Name)
            .IsUnique();
            
        modelBuilder.Entity<CarManufacturer>()
            .Property(cm => cm.Id)
            .ValueGeneratedOnAdd();
            
        modelBuilder.Entity<Car>()
            .HasKey(c => c.Id);
        
        modelBuilder.Entity<Car>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Car>()
            .HasOne(c => c.CarManufacturer)
            .WithMany(cm => cm.Cars)
            .HasForeignKey(c => c.CarManufacturerId);
            
        modelBuilder.Entity<Driver>()
            .HasKey(d => d.Id);
        
        modelBuilder.Entity<Driver>()
            .Property(d => d.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Driver>()
            .HasOne(d => d.Car)
            .WithMany(c => c.Drivers)
            .HasForeignKey(d => d.CarId);
        
        modelBuilder.Entity<Competition>()
            .HasKey(c => c.Id);
        
        modelBuilder.Entity<Competition>()
            .HasIndex(c => c.Name)
            .IsUnique();
        
        modelBuilder.Entity<Competition>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<DriverCompetition>()
            .HasKey(dc => new { dc.DriverId, dc.CompetitionId });
        
        modelBuilder.Entity<DriverCompetition>()
            .HasOne(dc => dc.Driver)
            .WithMany(d => d.DriverCompetitions)
            .HasForeignKey(dc => dc.DriverId);
        
        modelBuilder.Entity<DriverCompetition>()
            .HasOne(dc => dc.Competition)
            .WithMany(c => c.DriverCompetitions)
            .HasForeignKey(dc => dc.CompetitionId);
        
        // Seed data
        modelBuilder.Entity<CarManufacturer>().HasData(
                new CarManufacturer { Id = 1, Name = "Ferrari", RowVersion = new byte[0] },
                new CarManufacturer { Id = 2, Name = "Mercedes", RowVersion = new byte[0] },
                new CarManufacturer { Id = 3, Name = "Red Bull Racing", RowVersion = new byte[0] }
        );
        
        modelBuilder.Entity<Car>().HasData(
            new Car { Id = 1, CarManufacturerId = 1, ModelName = "SF21", Number = 5, RowVersion = new byte[0] },
            new Car { Id = 2, CarManufacturerId = 1, ModelName = "SF21", Number = 16, RowVersion = new byte[0] },
            new Car { Id = 3, CarManufacturerId = 2, ModelName = "W12", Number = 44, RowVersion = new byte[0] }
        );
    
        modelBuilder.Entity<Driver>().HasData(
            new Driver { Id = 1, FirstName = "Charles", LastName = "Leclerc", Birthday = new DateTime(1997, 10, 16), CarId = 2, RowVersion = new byte[0] },
            new Driver { Id = 2, FirstName = "Carlos", LastName = "Sainz", Birthday = new DateTime(1994, 9, 1), CarId = 1, RowVersion = new byte[0] },
            new Driver { Id = 3, FirstName = "Lewis", LastName = "Hamilton", Birthday = new DateTime(1985, 1, 7), CarId = 3, RowVersion = new byte[0] }
        );
    
        modelBuilder.Entity<Competition>().HasData(
            new Competition { Id = 1, Name = "Monaco Grand Prix", RowVersion = new byte[0] },
            new Competition { Id = 2, Name = "British Grand Prix", RowVersion = new byte[0] },
            new Competition { Id = 3, Name = "Italian Grand Prix", RowVersion = new byte[0] }
        );

        modelBuilder.Entity<DriverCompetition>().HasData(
            new DriverCompetition
                { DriverId = 1, CompetitionId = 1, Date = new DateTime(2023, 5, 23), RowVersion = new byte[0] },
            new DriverCompetition
                { DriverId = 2, CompetitionId = 1, Date = new DateTime(2023, 5, 23), RowVersion = new byte[0] },
            new DriverCompetition
                { DriverId = 3, CompetitionId = 1, Date = new DateTime(2023, 5, 23), RowVersion = new byte[0] });
    }
}
