using apiwithdb.Models;
using conexion_bd_tecweb.Models;

namespace apiwithdb.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Event? GetById(Guid id);
        void Add(Event ev);
        void Delete(Guid id);
    }
}
