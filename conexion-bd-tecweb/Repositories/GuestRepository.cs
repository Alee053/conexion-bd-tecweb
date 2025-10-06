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

        public async Task Delete(Guid id)
        {
            var guest = await _context.Guests.FirstOrDefaultAsync(x => x.Id == id);
            if (guest != null)
            {
                _context.Remove(guest);
            }
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _context.Guests.ToListAsync();
        }
        public async Task<Guest?> GetById(Guid id)
        {
            return await _context.Guests.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
