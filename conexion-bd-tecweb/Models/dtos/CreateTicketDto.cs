using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models.dtos
{
    public record CreateTicketDto
    {
        public string[]? Notes { get; init; }
    }
}
