using apiwithdb.Models;
using apiwithdb.Models.dtos;
using apiwithdb.Repositories;
using conexion_bd_tecweb.Models;
using conexion_bd_tecweb.Models.dtos;

namespace apiwithdb.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repo;

        public EventService(IEventRepository repo)
        {
            _repo = repo;
        }

        public Event Create(CreateEventDto dto)
        {
            if (dto.Capacity <= 0)
            {
                throw new InvalidOperationException("Capacity must be greater than zero.");
            }

            if (dto.Date < DateTime.UtcNow)
            {
                throw new InvalidOperationException("Event date must be in the future.");
            }

            var ev = new Event
            {
                Id = Guid.NewGuid(),
                Title = dto.Title.Trim(),
                Date = dto.Date,
                Capacity = dto.Capacity
            };

            _repo.Add(ev);
            return ev;
        }

        public bool Delete(Guid id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return false;

            _repo.Delete(id);
            return true;
        }

        public IEnumerable<Event> GetAll()
        {
            return _repo.GetAll();
        }

        public Event? GetById(Guid id)
        {
            return _repo.GetById(id);
        }
    }
}
