using System.ComponentModel.DataAnnotations;

namespace conexion_bd_tecweb.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
