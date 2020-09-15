using Codisa.Core.Entities;
using Codisa.Infrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Codisa.Test.Services
{
    [TestClass]
    public class AreaServicesTest
    {
        [TestMethod]
        public void CuandoGetAllAreas()
        {
            //Arrange
            //Act
            IAreaServices areaServices = Substitute.For<IAreaServices>();
            var result = areaServices.GetAllAreas();
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CuandoCreateArea()
        {
            //Arrange
            Area area = new Area { Nombre = "Redes", Descripcion = "Infraestructuras de Redes"};
            //Act
            IAreaServices areaServices = Substitute.For<IAreaServices>();
            var result = areaServices.CreateArea(area);
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CuandoUpdateArea()
        {
            //Arrange
            Area area = new Area { Nombre = "Redes", Descripcion = "Infraestructuras de Redes" };
            //Act
            IAreaServices areaServices = Substitute.For<IAreaServices>();
            var result = areaServices.UpdateArea(area);
            //Assert
            Assert.IsNotNull(result);
        }
    }
}
