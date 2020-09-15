using AutoMapper;
using Codisa.Core.Entities;
using Codisa.Infrastructure.ParamsDTO;

namespace Codisa.Infrastructure.Mapping
{
    public class InfrastructureMapping : Profile
    {
        #region CONTRUCTOR
        public InfrastructureMapping()
        {
            Mapping();
        }
        #endregion

        #region "METODOS"
        public void Mapping()
        {
            CreateMap<Area, AreaDto>().ReverseMap();
            CreateMap<Empleado, EmpleadoDto>().ReverseMap();
            CreateMap<EmpleadoHabilidad, EmpleadoHabilidadDto>().ReverseMap();
        }
        #endregion
    }
}
