using conexion_bd_tecweb.Models.dtos;
using conexion_bd_tecweb.Services;
using Microsoft.AspNetCore.Mvc;

namespace conexion_bd_tecweb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController: ControllerBase
    {
        private readonly ITicketService _service;
        public TicketsController(ITicketService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async  Task<IActionResult> GetOne(Guid id)
        {
            var ticket = _service.GetById(id);
            return await ticket == null
                ? NotFound(new { error = "Ticket not found", status = 404 })
                : Ok(ticket);
        }

        [HttpPost]
        public async  Task<IActionResult> Create([FromBody] CreateTicketDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var ticket = await _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = ticket.Id }, ticket);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = _service.Delete(id);
            return await success
                ? NoContent()
                : NotFound(new { error = "Ticket not found", status = 404 });
        }
    }
}
