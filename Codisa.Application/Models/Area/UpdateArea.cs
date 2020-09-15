using System.ComponentModel.DataAnnotations;

namespace Codisa.Application.Models.Area
{
    public class UpdateArea
    {
        [Required]
        public int IdArea { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(2), MaxLength(100)]
        public string Nombre { get; set; }
        [MaxLength(2000)]
        public string Descripcion { get; set; }
    }
}
