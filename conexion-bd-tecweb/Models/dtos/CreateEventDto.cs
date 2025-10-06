using System.ComponentModel.DataAnnotations;
namespace conexion_bd_tecweb.Models.dtos
{
    public class CreateEventDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Capacity { get; set; }
    }
}
