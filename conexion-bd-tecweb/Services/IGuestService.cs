using conexion_bd_tecweb.Models;
using conexion_bd_tecweb.Models.dtos;

namespace conexion_bd_tecweb.Services
{
    public interface IGuestService
    {
        Task<IEnumerable<Guest>> GetAll();
        Task<Guest?> GetById(Guid id);
        Task<Guest> Create(CreateGuestDto dto);
        Task<bool> Delete(Guid id);
    }
}
