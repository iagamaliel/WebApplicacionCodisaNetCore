using Codisa.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Codisa.Infrastructure.Repository.InterfacesRepository
{
    public interface IAreaRepository
    {
        Task<List<Area>> GetAllAreas();
        Task<int> CreateArea(Area area);
        Task<int> UpdateArea(Area area);
        Task<int> DeleteArea(int idArea);
    }
}
