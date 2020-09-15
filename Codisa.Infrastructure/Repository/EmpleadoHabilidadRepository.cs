using Codisa.Core.Entities;
using Codisa.Infrastructure.Interfaces;
using Codisa.Infrastructure.Repository.InterfacesRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codisa.Infrastructure.Repository
{
    public class EmpleadoHabilidadRepository : IEmpleadoHabilidadRepository
    {
        #region "ATRIBUTOS"
        private readonly IEmpleadoHabilidadServices _empleadoHabilidadServices;
        #endregion

        #region "CONSTRUCTOR"
        public EmpleadoHabilidadRepository(IEmpleadoHabilidadServices empleadoHabilidadServices)
        {
            _empleadoHabilidadServices = empleadoHabilidadServices ?? throw new ArgumentNullException(nameof(empleadoHabilidadServices));
        }
        #endregion

        #region "METODOS"
        public async Task<List<EmpleadoHabilidad>> GetAllEmployeeSkill(int idEmpleado)
        {
            return await _empleadoHabilidadServices.GetAllEmployeeSkill(idEmpleado);
        }

        public async Task<int> CreateEmployeeSkill(EmpleadoHabilidad empleadoHabilidad)
        {
            return await _empleadoHabilidadServices.CreateEmployeeSkill(empleadoHabilidad);
        }

        public async Task<int> DeleteEmployeeSkill(int idEmpleado)
        {
            return await _empleadoHabilidadServices.DeleteEmployeeSkill(idEmpleado);
        }
        #endregion
    }
}
