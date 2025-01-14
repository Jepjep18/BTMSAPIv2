using BTMSAPI.DTOs;
using BTMSAPI.Models;

namespace BTMSAPI.Services
{
    public interface IBusinessUnitService
    {
        Task<IEnumerable<BusinessUnit>> GetAllBusinessUnitAsync();
        Task<BusinessUnit?> GetBusinessUnitByIdAsync(int id);
        Task AddBusinessUnitAsync(BusinessUnitDTO businessUnitDTO);
        Task UpdateBusinessUnitAsync(BusinessUnit businessUnit);
        Task DeleteBusinessUnitAsync(int id);
    }
}
