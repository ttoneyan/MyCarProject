using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCar.API.Models;

namespace MyCar.API.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    public DbSet<Cars> Cars { get; set; }
    public DbSet<Dealers> Dealers { get; set; }
    public DbSet<Bookings> Bookings { get; set; }
    public DbSet<LoanApplications> LoanApplications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cars>()
            .HasOne(c => c.Dealer)
            .WithMany(d => d.Cars)
            .HasForeignKey(c => c.DealerId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Bookings>()
            .HasOne(b => b.Dealer)
            .WithMany()
            .HasForeignKey(b => b.DealerId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Bookings>()
            .HasOne(b => b.Car)
            .WithMany()
            .HasForeignKey(b => b.CarId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<LoanApplications>()
            .HasOne(l => l.Dealer)
            .WithMany()
            .HasForeignKey(l => l.DealerId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<LoanApplications>()
            .HasOne(l => l.Car)
            .WithMany()
            .HasForeignKey(l => l.CarId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<LoanApplications>()
            .HasOne(l => l.User)
            .WithMany()
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Bookings>()
            .HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Cars>()
            .Property(x => x.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<ApplicationUser>()
            .Property(x => x.Salary)
            .HasPrecision(18, 2);

        modelBuilder.Entity<LoanApplications>()
            .Property(x => x.RequestedAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<LoanApplications>()
            .Property(x => x.DownPayment)
            .HasPrecision(18, 2);
    }
}