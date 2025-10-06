using conexion_bd_tecweb.Models;

namespace conexion_bd_tecweb.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event?> GetById(Guid id);
        Task Add(Event ev);
        Task Delete(Guid id);
    }
}
