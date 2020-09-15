using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codisa.Infrastructure.ParamsDTO
{
    public class EmpleadoDto
    {
        public int IdEmpleado { get; set; }
        public string NombreCompleto { get; set; }
        public string Cedula { get; set; }
        public string Correo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string FechaNacimientoFormat
        {
            get
            {
                return FechaNacimiento.ToString("dd/MM/yyyy");
            }
        }
        [NotMapped]
        [Display(Name = "Edad")]
        public int Edad
        {
            get
            {
                int edad = DateTime.Today.Year - FechaNacimiento.Year;

                if (DateTime.Today.Month < FechaNacimiento.Month)
                    --edad;
                else if (DateTime.Today.Month == FechaNacimiento.Month && DateTime.Today.Day < FechaNacimiento.Day)
                    --edad;

                return edad;
            }
        }
        public DateTime FechaIngreso { get; set; }
        public string FechaIngresoFormat
        {
            get
            {
                return FechaIngreso.ToString("dd/MM/yyyy");
            }
        }
        [NotMapped]
        [Display(Name = "AniosLaborando")]
        public int AniosLaborando
        {
            get
            {
                int edad = DateTime.Today.Year - FechaIngreso.Year;

                if (DateTime.Today.Month < FechaIngreso.Month)
                    --edad;
                else if (DateTime.Today.Month == FechaIngreso.Month && DateTime.Today.Day < FechaIngreso.Day)
                    --edad;

                return edad;
            }
        }
        public int IdJefe { get; set; }
        public int IdArea { get; set; }
        public string Foto { get; set; }
    }
}
