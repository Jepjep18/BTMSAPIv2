using BTMSAPI.Data;
using BTMSAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BTMSAPI.Repositories
{
    public class BusinessUnitRepository: IBusinessUnitRepository
    {
        private readonly ApplicationDbContext _context;

        public BusinessUnitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BusinessUnit>> GetAllBusinessUnitAsync()
        {
            return await _context.BusinessUnit.ToListAsync();
        }

        public async Task<BusinessUnit?> GetBusinessUnitByIdAsync(int id)
        {
            return await _context.BusinessUnit.FindAsync(id);
        }

        public async Task AddBusinessUnitAsync(BusinessUnit businessUnit)
        {
            await _context.BusinessUnit.AddAsync(businessUnit);
        }

        public async Task UpdateBusinessUnitAsync(BusinessUnit businessUnit)
        {
            _context.BusinessUnit.Update(businessUnit);
        }

        public async Task DeleteBusinessUnitAsync(int id)
        {
            var businessUnit = await GetBusinessUnitByIdAsync(id);
            if (businessUnit != null)
            {
                _context.BusinessUnit.Remove(businessUnit);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
