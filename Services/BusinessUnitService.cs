using BTMSAPI.DTOs;
using BTMSAPI.Models;
using BTMSAPI.Repositories;

namespace BTMSAPI.Services
{
    public class BusinessUnitService : IBusinessUnitService
    {
        private readonly IBusinessUnitRepository _repository;

        public BusinessUnitService(IBusinessUnitRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BusinessUnit>> GetAllBusinessUnitAsync()
        {
            return await _repository.GetAllBusinessUnitAsync();
        }

        public async Task<BusinessUnit?> GetBusinessUnitByIdAsync(int id)
        {
            return await _repository.GetBusinessUnitByIdAsync(id);
        }

        public async Task AddBusinessUnitAsync(BusinessUnitDTO businessUnitDTO)
        {
            var businessUnit = new BusinessUnit
            {
                BusinessunitName = businessUnitDTO.BusinessunitName,
                BusinessunitDescription = businessUnitDTO.BusinessunitDescription,
                BusinessLocation = businessUnitDTO.BusinessLocation
            };

            await _repository.AddBusinessUnitAsync(businessUnit);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateBusinessUnitAsync(BusinessUnit businessUnit)
        {
            await _repository.UpdateBusinessUnitAsync(businessUnit);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteBusinessUnitAsync(int id)
        {
            await _repository.DeleteBusinessUnitAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
