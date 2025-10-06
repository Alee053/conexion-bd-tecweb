using conexion_bd_tecweb.Models;
using conexion_bd_tecweb.Models.dtos;

namespace conexion_bd_tecweb.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetById(Guid id);
        Task<Book> Create(CreateBookDto dto);
        Task<bool> Delete(Guid id);
    }
}
