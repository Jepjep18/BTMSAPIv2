using BTMSAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Repositories
{
    public interface IBatteryReturnedItemsRepository
    {
        Task<IEnumerable<BatteryReturnedItems>> GetAllBatteryReturnedItems();
        Task<BatteryReturnedItems> GetBatteryReturnedItemById(int id);
        Task AddBatteryReturnedItem(BatteryReturnedItems batteryReturnedItem);
        Task UpdateBatteryReturnedItem(BatteryReturnedItems batteryReturnedItem);
        Task DeleteBatteryReturnedItem(int id);
        Task SaveChangesAsync();
    }
}