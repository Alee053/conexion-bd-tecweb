using conexion_bd_tecweb.Models;
using conexion_bd_tecweb.Data;
using Microsoft.EntityFrameworkCore;

namespace conexion_bd_tecweb.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Ticket ticket)
        {   
           await _context.AddAsync(ticket);
        }

        public async Task Delete(Guid id)
        {
            var ticket=await _context.Tickets.FirstOrDefaultAsync(x=>x.Id==id);
            if (ticket != null)
            {
                _context.Remove(ticket);
            }
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
           return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket?> GetById(Guid id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
