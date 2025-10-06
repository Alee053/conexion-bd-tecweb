using conexion_bd_tecweb.Models;

namespace conexion_bd_tecweb.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket?> GetById(Guid id);
        Task Add(Ticket ticket);
        Task Delete(Guid id);
    }
}
