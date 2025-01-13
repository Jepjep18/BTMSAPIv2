using BTMSAPI.Models;

namespace BTMSAPI.Repositories
{
    public class IBusinessUnitRepository
    {
        Task<IEnumerable<BusinessUnit>> GetAllBusinessUnitAsync();
        Task<BusinessUnit?> GetBusinessUnitByIdAsync(int id);
        Task AddBusinessUnitAsync(BusinessUnit businessUnit);
        Task UpdateBusinessUnitAsync(BusinessUnit businessUnit, int id);
        Task DeleteBusinessUnitAsync(int id);
        Task SaveChangesAsync();
    }
}
