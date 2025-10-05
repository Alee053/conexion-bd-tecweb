using conexion_bd_tecweb.Models;
using Microsoft.EntityFrameworkCore;

namespace conexion_bd_tecweb.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Title).IsRequired().HasMaxLength(200);
                b.Property(x => x.Year).IsRequired();
            });
            modelBuilder.Entity<Ticket>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Notes);
            });
        }
    }
}
