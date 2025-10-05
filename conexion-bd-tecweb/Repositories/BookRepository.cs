using conexion_bd_tecweb.Models;
using conexion_bd_tecweb.Data;
using Microsoft.EntityFrameworkCore;

namespace conexion_bd_tecweb.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Book book)
        {   
           await _context.AddAsync(book);
        }

        public async Task Delete(Guid id)
        {
            var book=await _context.Books.FirstOrDefaultAsync(x=>x.Id==id);
            if (book != null)
            {
                _context.Remove(book);
            }
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
           return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetById(Guid id)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
