using BTMSAPI.Models;
using BTMSAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Services
{
    public class BatteryReleasedItemsService : IBatteryReleasedItemsService
    {
        private readonly IBatteryReleasedItemsRepository _repository;
        private readonly IBatteryItemRepository _batteryItemRepository;


        public BatteryReleasedItemsService(IBatteryReleasedItemsRepository repository, IBatteryItemRepository batteryItemRepository)
        {
            _repository = repository;
            _batteryItemRepository = batteryItemRepository;
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
            var batteryItem = await _batteryItemRepository.GetBatteryItemById(batteryReleasedItem.BatteryItemId.Value);
            if (batteryItem != null)
            {
                batteryItem.Status = "RELEASED";
                await _batteryItemRepository.UpdateBatteryItem(batteryItem);
            }

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