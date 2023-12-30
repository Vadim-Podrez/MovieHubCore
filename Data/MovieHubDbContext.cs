using Microsoft.EntityFrameworkCore;
using MovieHubCore.Models;

namespace MovieHubCore.Domain
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Repertoire> Repertoires { get; set; }
        public DbSet<Seat> Seats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Встановлення первинних ключів
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);
            modelBuilder.Entity<Position>().HasKey(p => p.PositionId);
            modelBuilder.Entity<Genre>().HasKey(g => g.GenreId);
            modelBuilder.Entity<Movie>().HasKey(m => m.MovieId);
            modelBuilder.Entity<Repertoire>().HasKey(r => r.SessionId);
            modelBuilder.Entity<Seat>().HasKey(s => s.SeatId);

            // Встановлення зв'язків між таблицями
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId);

            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(m => m.GenreId);

            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Employee)
                .WithMany()
                .HasForeignKey(s => s.EmployeeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
