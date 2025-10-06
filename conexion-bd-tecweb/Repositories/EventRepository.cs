using apiwithdb.Data;
using apiwithdb.Models;
using conexion_bd_tecweb.Models;

namespace apiwithdb.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events.ToList();
        }

        public Event? GetById(Guid id)
        {
            return _context.Events.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Event ev)
        {
            _context.Events.Add(ev);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var ev = _context.Events.FirstOrDefault(e => e.Id == id);
            if (ev != null)
            {
                _context.Events.Remove(ev);
                _context.SaveChanges();
            }
        }
    }

}
