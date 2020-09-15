using Codisa.Core.Entities;
using Codisa.Infrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Codisa.Test.Services
{
    [TestClass]
    public class EmpleadoHabilidadServicesTest
    {
        [TestMethod]
        public void CuandoGetAllEmployeeSkill()
        {
            //Arrange
            int id = 1;
            //Act
            IEmpleadoHabilidadServices empleadoHabilidadServices = Substitute.For<IEmpleadoHabilidadServices>();
            var result = empleadoHabilidadServices.GetAllEmployeeSkill(id);
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CuandoCreateEmployeeSkill()
        {
            //Arrange
            EmpleadoHabilidad empleadoHabilidad = new EmpleadoHabilidad
            {
                IdEmpleado = 1,
                IdHabilidad = 1,
                NombreHabilidad = "Redes"
            };

            //Act
            IEmpleadoHabilidadServices empleadoHabilidadServices = Substitute.For<IEmpleadoHabilidadServices>();
            var result = empleadoHabilidadServices.CreateEmployeeSkill(empleadoHabilidad);
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CuandoDeleteEmployeeSkill()
        {
            //Arrange
            int id = 1;

            //Act
            IEmpleadoHabilidadServices empleadoHabilidadServices = Substitute.For<IEmpleadoHabilidadServices>();
            var result = empleadoHabilidadServices.DeleteEmployeeSkill(id);
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
