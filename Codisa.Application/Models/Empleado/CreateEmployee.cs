using System;
using System.ComponentModel.DataAnnotations;

namespace Codisa.Application.Models.Empleado
{
    public class CreateEmployee
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MinLength(3), MaxLength(100)]
        public string NombreCompleto { get; set; }

        [MaxLength(50)]
        public string Cedula { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string Correo { get; set; }
        [Required(ErrorMessage = "La fecha de Nacmiento es requerida")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "La fecha de ingreso es requerida")]
        public DateTime FechaIngreso { get; set; }
        public int IdJefe { get; set; }
        public int IdArea { get; set; }
    }
}
