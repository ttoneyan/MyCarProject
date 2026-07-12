using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Users> Users { get; set; }
    public DbSet<Cars> Cars { get; set; }
    public DbSet<Dealers> Dealers { get; set; }
    public DbSet<Bookings> Bookings { get; set; }
    public DbSet<LoanApplications> LoanApplications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // =========================
        // DEALER → CARS (ONLY CASCADE)
        // =========================
        modelBuilder.Entity<Cars>()
            .HasOne(c => c.Dealer)
            .WithMany(d => d.Cars)
            .HasForeignKey(c => c.DealerId)
            .OnDelete(DeleteBehavior.Cascade);

        // =========================
        // BOOKING → DEALER (NO ACTION)
        // =========================
        modelBuilder.Entity<Bookings>()
            .HasOne(b => b.Dealer)
            .WithMany()
            .HasForeignKey(b => b.DealerId)
            .OnDelete(DeleteBehavior.NoAction);

        // =========================
        // BOOKING → CAR (NO ACTION or CASCADE depending on your logic)
        // =========================
        modelBuilder.Entity<Bookings>()
            .HasOne(b => b.Car)
            .WithMany()
            .HasForeignKey(b => b.CarId)
            .OnDelete(DeleteBehavior.NoAction);

        // =========================
        // BOOKING → USER
        // =========================
        modelBuilder.Entity<Bookings>()
            .HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        // =========================
        // LOANAPPLICATION → DEALER (NO ACTION)
        // =========================
        modelBuilder.Entity<LoanApplications>()
            .HasOne(l => l.Dealer)
            .WithMany()
            .HasForeignKey(l => l.DealerId)
            .OnDelete(DeleteBehavior.NoAction);

        // =========================
        // LOANAPPLICATION → CAR (NO ACTION or CASCADE if needed)
        // =========================
        modelBuilder.Entity<LoanApplications>()
            .HasOne(l => l.Car)
            .WithMany()
            .HasForeignKey(l => l.CarId)
            .OnDelete(DeleteBehavior.NoAction);

        // =========================
        // LOANAPPLICATION → USER
        // =========================
        modelBuilder.Entity<LoanApplications>()
            .HasOne(l => l.User)
            .WithMany()
            .HasForeignKey(l => l.UserId)
            .OnDelete(DeleteBehavior.NoAction);


        modelBuilder.Entity<Cars>()
   .Property(x => x.Price)
   .HasPrecision(18, 2);

        modelBuilder.Entity<Users>()
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