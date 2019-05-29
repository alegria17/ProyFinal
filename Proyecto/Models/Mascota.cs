using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public class Mascota
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        public string Foto { get; set; }

        [Required]
        public decimal Precio { get; set; }
    }
}