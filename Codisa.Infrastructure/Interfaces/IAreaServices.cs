using Codisa.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Codisa.Infrastructure.Interfaces
{
    public interface IAreaServices
    {
        Task<List<Area>> GetAllAreas();
        Task<int> CreateArea(Area area);
        Task<int> UpdateArea(Area area);
        Task<int> DeleteArea(int idArea);
    }
}
