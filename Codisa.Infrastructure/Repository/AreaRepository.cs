using Codisa.Core.Entities;
using Codisa.Infrastructure.Interfaces;
using Codisa.Infrastructure.Repository.InterfacesRepository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codisa.Infrastructure.Repository
{
    public class AreaRepository : IAreaRepository
    {
        #region "ATRIBUTOS"
        private readonly IAreaServices _areaServices;
        #endregion

        #region "CONSTRUCTOR"
        public AreaRepository(IAreaServices areaServices)
        {
            _areaServices = areaServices ?? throw new ArgumentNullException(nameof(areaServices));
        }
        #endregion

        #region "METODOS"
        public async Task<List<Area>> GetAllAreas()
        {
            return await _areaServices.GetAllAreas();
        }

        public async Task<int> CreateArea(Area area)
        {
            return await _areaServices.CreateArea(area);
        }

        public async Task<int> UpdateArea(Area area)
        {
            return await _areaServices.UpdateArea(area);
        }

        public async Task<int> DeleteArea(int idArea)
        {
            return await _areaServices.DeleteArea(idArea);
        }
        #endregion

    }
}
