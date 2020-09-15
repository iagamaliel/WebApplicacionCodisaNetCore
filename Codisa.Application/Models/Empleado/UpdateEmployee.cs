using System;
using System.ComponentModel.DataAnnotations;

namespace Codisa.Application.Models.Empleado
{
    public class UpdateEmployee
    {
        public int IdEmpleado { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }
        public int IdJefe { get; set; }
        public int IdArea { get; set; }
    }
}
