using Codisa.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codisa.Infrastructure.Interfaces
{
    public interface IEmpleadoServices
    {
        Task<List<Empleado>> GetAllEmployee();
        Task<int> CreateEmployee(Empleado empleado);
        Task<int> UpdateEmployee(Empleado empleado);
        Task<int> DeleteEmployee(int idEmpleado);
    }
}
