using conexion_bd_tecweb.Models;
using Microsoft.EntityFrameworkCore;

namespace conexion_bd_tecweb.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Guest> Guests => Set<Guest>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Event> Events => Set<Event>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).IsRequired().HasMaxLength(200);
                b.Property(x => x.Year).IsRequired();
            });
            modelBuilder.Entity<Guest>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.FullName).IsRequired().HasMaxLength(200);
                b.Property(x => x.Confirmed).IsRequired();
            });
            modelBuilder.Entity<Ticket>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Notes);
            });
            modelBuilder.Entity<Event>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).IsRequired().HasMaxLength(200);
                b.Property(x => x.Date).IsRequired();
                b.Property(x => x.Capacity).IsRequired();
            });
        }
    }
}
