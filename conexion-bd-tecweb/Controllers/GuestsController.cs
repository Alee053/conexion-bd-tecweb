using apiwithdb.Models.dtos;
using apiwithdb.Services;
using Microsoft.AspNetCore.Mvc;

namespace conexion_bd_tecweb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService _service;
        public GuestsController(IGuestService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
    }
}
