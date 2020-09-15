using AutoMapper;
using Codisa.Application.Models.Empleado;
using Codisa.Application.Models.Area;
using Codisa.Core.Entities;

namespace Codisa.Application.Mapping
{
    public class ApplicationMapping : Profile
    {
        #region CONTRUCTOR
        public ApplicationMapping()
        {
            Mapping();
        }
        #endregion

        #region METODOS
        private void Mapping()
        {
            CreateMap<Area, CreateArea>().ReverseMap();
            CreateMap<Area, UpdateArea>().ReverseMap();

            CreateMap<Empleado, CreateEmployee>().ReverseMap();
            CreateMap<Empleado, UpdateEmployee>().ReverseMap();

            CreateMap<EmpleadoHabilidad, CreateEmployeeSkill>().ReverseMap();
        }
        #endregion

    }
}
