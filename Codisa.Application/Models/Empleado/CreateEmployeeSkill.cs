using System.ComponentModel.DataAnnotations;

namespace Codisa.Application.Models.Empleado
{
    public class CreateEmployeeSkill
    {
        [Required]
        public int IdEmpleado { get; set; }
        [Required]
        public string NombreHabilidad { get; set; }
    }
}
