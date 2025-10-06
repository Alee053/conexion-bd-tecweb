using conexion_bd_tecweb.Models;

namespace conexion_bd_tecweb.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetById(Guid id);
        Task Add(Book book);
        Task Delete(Guid id);
    }
}
