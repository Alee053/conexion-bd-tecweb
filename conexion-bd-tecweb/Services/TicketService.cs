using conexion_bd_tecweb.Models;
using conexion_bd_tecweb.Models.dtos;
using conexion_bd_tecweb.Repositories;

namespace conexion_bd_tecweb.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repo;
        public TicketService(ITicketRepository repo)
        {
            _repo = repo;
        }
        public async Task<Ticket> Create(CreateTicketDto dto)
        {
            var ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                Notes = dto.Notes
            };
            await _repo.Add(ticket);
            return ticket;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;
            await _repo.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Ticket>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Ticket?> GetById(Guid id)
        {
            var ticket = await _repo.GetById(id);
            return ticket;
        }
    }
}
