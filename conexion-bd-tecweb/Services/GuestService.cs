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
    }
}
