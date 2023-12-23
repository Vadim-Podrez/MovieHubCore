using Microsoft.EntityFrameworkCore;
using MovieHubCore.Models;

namespace MovieHubCore.Domain;

public class CinemaDbContext : DbContext
{
    public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Position> Positions { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Repertoire> Repertoires { get; set; }
    public DbSet<Seat> Seats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Здійсніть налаштування моделі, якщо потрібно
        // Наприклад, встановлення зв'язків між таблицями
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Position)
            .WithMany()
            .HasForeignKey(e => e.PositionId);

        modelBuilder.Entity<Movie>()
            .HasOne(m => m.Genre)
            .WithMany()
            .HasForeignKey(m => m.GenreId);

        modelBuilder.Entity<Seat>()
            .HasOne(s => s.Employee)
            .WithMany()
            .HasForeignKey(s => s.EmployeeId);

        base.OnModelCreating(modelBuilder);
    }
}
