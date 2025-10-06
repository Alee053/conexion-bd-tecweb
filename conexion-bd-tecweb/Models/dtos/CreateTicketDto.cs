using System.ComponentModel.DataAnnotations;

namespace conexion_bd_tecweb.Models.dtos
{
    public record CreateTicketDto
    {
        public string[]? Notes { get; init; }
    }
}
