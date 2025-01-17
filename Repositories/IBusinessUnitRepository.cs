﻿using BTMSAPI.Models;

namespace BTMSAPI.Repositories
{
    public interface IBusinessUnitRepository
    {
        Task<IEnumerable<BusinessUnit>> GetAllBusinessUnitAsync();
        Task<BusinessUnit?> GetBusinessUnitByIdAsync(int id);
        Task AddBusinessUnitAsync(BusinessUnit businessUnit);
        Task UpdateBusinessUnitAsync(BusinessUnit businessUnit);
        Task DeleteBusinessUnitAsync(int id);
        Task SaveChangesAsync();
    }
}
