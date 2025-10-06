using apiwithdb.Models;
using conexion_bd_tecweb.Models;

namespace conexion_bd_tecweb.Repositories
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
        Task Add(Guest guest);
        Task Delete(Guid id);
    }
}
