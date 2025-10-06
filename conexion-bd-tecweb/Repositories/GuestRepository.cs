using apiwithdb.Models;
using conexion_bd_tecweb.Data;
using conexion_bd_tecweb.Models;
using Microsoft.EntityFrameworkCore;
namespace conexion_bd_tecweb.Repositories
{
    public class GuestRepository: IGuestRepository
    {
        private readonly AppDbContext _context;

        public GuestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Guest guest)
        {
            await _context.AddAsync(guest);
            await _context.SaveChangesAsync();
        }
    }
}
