using conexion_bd_tecweb.Models;
using conexion_bd_tecweb.Models.dtos;
using conexion_bd_tecweb.Repositories;

namespace conexion_bd_tecweb.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _repo;

        public EventService(IEventRepository repo)
        {
            _repo = repo;
        }

        public async Task<Event> Create(CreateEventDto dto)
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

            await _repo.Add(ev);
            return ev;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existing = await _repo.GetById(id);
            if (existing == null) return false;

           await  _repo.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Event?> GetById(Guid id)
        {
            return await _repo.GetById(id);
        }
    }
}
