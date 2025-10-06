using apiwithdb.Models.dtos;
using apiwithdb.Services;
using conexion_bd_tecweb.Models.dtos;
using Microsoft.AspNetCore.Mvc;

namespace apiwithdb.Controllers
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
        public IActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetOne(Guid id)
        {
            var ev = _service.GetById(id);
            return ev == null
                ? NotFound(new { error = "Event not found", status = 404 })
                : Ok(ev);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateEventDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var ev = _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = ev.Id }, ev);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var success = _service.Delete(id);
            return success
                ? NoContent()
                : NotFound(new { error = "Event not found", status = 404 });
        }
    }
}
