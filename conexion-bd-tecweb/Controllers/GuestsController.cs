using apiwithdb.Models.dtos;
using apiwithdb.Services;
using conexion_bd_tecweb.Models.dtos;
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

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var guest = _service.GetById(id);
            return await guest == null
                ? NotFound(new { error = "Guest not found", status = 404 })
                : Ok(guest);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGuestDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var guest = await _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = guest.Id }, guest);
        }
    }
}
