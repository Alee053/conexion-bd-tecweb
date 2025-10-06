using conexion_bd_tecweb.Models.dtos;
using conexion_bd_tecweb.Services;
using conexion_bd_tecweb.Models.dtos;
using Microsoft.AspNetCore.Mvc;

namespace conexion_bd_tecweb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _service;

        public EventsController(IEventService service)
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
            var ev = await _service.GetById(id);
            return ev == null
                ? NotFound(new { error = "Event not found", status = 404 })
                : Ok(ev);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var ev = await _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = ev.Id }, ev);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.Delete(id);
            return success
                ? NoContent()
                : NotFound(new { error = "Event not found", status = 404 });
        }
    }
}
