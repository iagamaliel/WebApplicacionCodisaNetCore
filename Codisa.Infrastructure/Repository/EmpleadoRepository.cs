using Codisa.Core.Entities;
using Codisa.Infrastructure.Interfaces;
using Codisa.Infrastructure.Repository.InterfacesRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codisa.Infrastructure.Repository
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        #region "ATRIBUTOS"
        private readonly IEmpleadoServices _empleadoServices;
        #endregion

        #region "CONSTRUCTOR"
        public EmpleadoRepository(IEmpleadoServices empleadoServices)
        {
            _empleadoServices = empleadoServices ?? throw new ArgumentNullException(nameof(empleadoServices));
        }
        #endregion

        #region "METODOS"
        public async Task<List<Empleado>> GetAllEmployee()
        {
            return await _empleadoServices.GetAllEmployee();
        }

        public async Task<int> CreateEmployee(Empleado empleado)
        {
            return await _empleadoServices.CreateEmployee(empleado);
        }

        public async Task<int> UpdateEmployee(Empleado empleado)
        {
            return await _empleadoServices.UpdateEmployee(empleado);
        }

        public async Task<int> DeleteEmployee(int idEmpleado)
        {
            return await _empleadoServices.DeleteEmployee(idEmpleado);
        }
        #endregion
    }
}
