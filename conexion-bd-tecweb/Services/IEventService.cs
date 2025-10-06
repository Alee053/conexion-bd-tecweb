using conexion_bd_tecweb.Models;
using conexion_bd_tecweb.Models.dtos;

namespace conexion_bd_tecweb.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task<Event> Create(CreateEventDto dto);
        Task<bool> Delete(Guid id);
    }
}
