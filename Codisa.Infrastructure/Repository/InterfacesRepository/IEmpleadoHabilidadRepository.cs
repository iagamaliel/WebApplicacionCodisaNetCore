using Codisa.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codisa.Infrastructure.Repository.InterfacesRepository
{
    public interface IEmpleadoHabilidadRepository
    {
        Task<List<EmpleadoHabilidad>> GetAllEmployeeSkill(int idEmpleado);
        Task<int> CreateEmployeeSkill(EmpleadoHabilidad empleadoHabilidad);
        Task<int> DeleteEmployeeSkill(int idHabilidad);
    }
}
