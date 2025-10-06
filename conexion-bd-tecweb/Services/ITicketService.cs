using conexion_bd_tecweb.Models;
using conexion_bd_tecweb.Models.dtos;

namespace conexion_bd_tecweb.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetAll();
        Task<Ticket?> GetById(Guid id);
        Task<Ticket> Create(CreateTicketDto dto);
        Task<bool> Delete(Guid id);
    }
}
