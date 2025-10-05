using apiwithdb.Models;
using apiwithdb.Data;
using Microsoft.EntityFrameworkCore;

namespace apiwithdb.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;


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
