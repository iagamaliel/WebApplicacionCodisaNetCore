using Codisa.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codisa.Infrastructure.Repository.InterfacesRepository
{
    public interface IEmpleadoRepository
    {
        Task<List<Empleado>> GetAllEmployee();
        Task<int> CreateEmployee(Empleado empleado);
        Task<int> UpdateEmployee(Empleado empleado);
        Task<int> DeleteEmployee(int idEmpleado);
    }
}
