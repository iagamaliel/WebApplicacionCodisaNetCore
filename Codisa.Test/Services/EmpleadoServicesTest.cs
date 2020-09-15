using Codisa.Core.Entities;
using Codisa.Infrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Codisa.Test.Services
{
    [TestClass]
    public class EmpleadoServicesTest
    {
        [TestMethod]
        public void CuandoGetAllEmployee()
        {
            //Arrange
            //Act
            IEmpleadoServices empleadoServices = Substitute.For<IEmpleadoServices>();
            var result = empleadoServices.GetAllEmployee();
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CuandoCreateEmployee()
        {
            //Arrange
            Empleado empleado = new Empleado () {
                IdEmpleado = 1,
                IdArea = 1,
                IdJefe = 1,
                Cedula = "0001",
                Correo = "correo@hotmail.com",
                NombreCompleto = "Caleb Jonathan Salazar Calles"
            };

            //Act
            IEmpleadoServices empleadoServices = Substitute.For<IEmpleadoServices>();
            var result = empleadoServices.CreateEmployee(empleado);
            //Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void CuandoUpdateEmployee()
        {
            //Arrange
            Empleado empleado = new Empleado()
            {
                IdEmpleado = 1,
                IdArea = 1,
                IdJefe = 1,
                Cedula = "0001",
                Correo = "correo@hotmail.com",
                NombreCompleto = "Caleb Jonathan Salazar Calles"
            };

            //Act
            IEmpleadoServices empleadoServices = Substitute.For<IEmpleadoServices>();
            var result = empleadoServices.UpdateEmployee(empleado);
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CuandoDeleteEmployee()
        {
            //Arrange
            int id = 1;

            //Act
            IEmpleadoServices empleadoServices = Substitute.For<IEmpleadoServices>();
            var result = empleadoServices.DeleteEmployee(id);
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
