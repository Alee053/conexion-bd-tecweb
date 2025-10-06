using conexion_bd_tecweb.Data;
using conexion_bd_tecweb.Models;
using Microsoft.EntityFrameworkCore;
namespace conexion_bd_tecweb.Repositories
{
    public class GuestRepository
    {
        private readonly AppDbContext _context;

        public GuestRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
