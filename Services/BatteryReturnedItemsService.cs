using BTMSAPI.Models;
using BTMSAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Services
{
    public class BatteryReturnedItemsService : IBatteryReturnedItemsService
    {
        private readonly IBatteryReturnedItemsRepository _repository;
        private readonly IBatteryReleasedItemsRepository _batteryReleasedItemsRepository;
        private readonly IBatteryItemRepository _batteryItemRepository;



        public BatteryReturnedItemsService(IBatteryReturnedItemsRepository repository, IBatteryReleasedItemsRepository batteryReleasedItemsRepository, IBatteryItemRepository batteryItemRepository)
        {
            _repository = repository;
            _batteryReleasedItemsRepository = batteryReleasedItemsRepository;
            _batteryItemRepository = batteryItemRepository;
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
            var batteryReleasedItem = await _batteryReleasedItemsRepository.GetBatteryReleasedItemById(batteryReturnedItem.BatteryReleasedItemId.Value);
            if (batteryReleasedItem != null)
            {
                var batteryItem = await _batteryItemRepository.GetBatteryItemById(batteryReleasedItem.BatteryItemId.Value);
                if (batteryItem != null)
                {
                    batteryItem.Status = "RETURNED";
                    await _batteryItemRepository.UpdateBatteryItem(batteryItem);
                }
            }

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