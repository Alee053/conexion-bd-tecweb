using apiwithdb.Models;
using apiwithdb.Models.dtos;
using conexion_bd_tecweb.Models;
using conexion_bd_tecweb.Models.dtos;
using conexion_bd_tecweb.Repositories;

namespace conexion_bd_tecweb.Services
{
    public class GuestService: IGuestService
    {
        private readonly IGuestRepository _repo;
        public GuestService(IGuestRepository repo)
        {
            _repo = repo;
        }
        public async Task<Guest> Create(CreateGuestDto dto)
        {
            var guest = new Guest
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName.Trim(),
                Confirmed = dto.Confirmed
            };
            await _repo.Add(guest);
            return guest;
        }
        public async Task<bool> Delete(Guid id)
        {
            var existing = _repo.GetById(id);
            if (existing == null) return false;
            await _repo.Delete(id);
            return true;
        }

        public async Task<IEnumerable<Guest>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<Guest?> GetById(Guid id)
        {
            var guest = _repo.GetById(id);
            return await guest;
        }
    }
}
