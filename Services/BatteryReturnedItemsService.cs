using BTMSAPI.Models;
using BTMSAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Services
{
    public class BatteryReturnedItemsService : IBatteryReturnedItemsService
    {
        private readonly IBatteryReturnedItemsRepository _repository;

        public BatteryReturnedItemsService(IBatteryReturnedItemsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BatteryReturnedItems>> GetAllBatteryReturnedItems()
        {
            return await _repository.GetAllBatteryReturnedItems();
        }

        public async Task<BatteryReturnedItems> GetBatteryReturnedItemById(int id)
        {
            return await _repository.GetBatteryReturnedItemById(id);
        }

        public async Task AddBatteryReturnedItem(BatteryReturnedItems batteryReturnedItem)
        {
            await _repository.AddBatteryReturnedItem(batteryReturnedItem);
        }

        public async Task UpdateBatteryReturnedItem(BatteryReturnedItems batteryReturnedItem)
        {
            await _repository.UpdateBatteryReturnedItem(batteryReturnedItem);
        }

        public async Task DeleteBatteryReturnedItem(int id)
        {
            await _repository.DeleteBatteryReturnedItem(id);
        }
    }
}