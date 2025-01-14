using BTMSAPI.Models;
using BTMSAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Services
{
    public class BatteryReleasedItemsService : IBatteryReleasedItemsService
    {
        private readonly IBatteryReleasedItemsRepository _repository;

        public BatteryReleasedItemsService(IBatteryReleasedItemsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BatteryReleasedItems>> GetAllBatteryReleasedItems()
        {
            return await _repository.GetAllBatteryReleasedItems();
        }

        public async Task<BatteryReleasedItems> GetBatteryReleasedItemById(int id)
        {
            return await _repository.GetBatteryReleasedItemById(id);
        }

        public async Task AddBatteryReleasedItem(BatteryReleasedItems batteryReleasedItem)
        {
            await _repository.AddBatteryReleasedItem(batteryReleasedItem);
        }

        public async Task UpdateBatteryReleasedItem(BatteryReleasedItems batteryReleasedItem)
        {
            await _repository.UpdateBatteryReleasedItem(batteryReleasedItem);
        }

        public async Task DeleteBatteryReleasedItem(int id)
        {
            await _repository.DeleteBatteryReleasedItem(id);
        }
    }
}