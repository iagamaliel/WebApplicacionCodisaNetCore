using System;

namespace Codisa.Core.Entities
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdJefe { get; set; }
        public int IdArea { get; set; }
        public  string Foto { get; set; }
    }
}
