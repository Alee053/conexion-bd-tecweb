using conexion_bd_tecweb.Data;
using conexion_bd_tecweb.Models;
using Microsoft.EntityFrameworkCore;

namespace conexion_bd_tecweb.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event?> GetById(Guid id)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Add(Event ev)
        {
            await _context.Events.AddAsync(ev);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var ev = await _context.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (ev != null)
            {   
                _context.Events.Remove(ev);
                await _context.SaveChangesAsync();
            }
        }
    }

}
