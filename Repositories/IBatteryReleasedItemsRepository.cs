using BTMSAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Repositories
{
    public interface IBatteryReleasedItemsRepository
    {
        Task<IEnumerable<BatteryReleasedItems>> GetAllBatteryReleasedItems();
        Task<BatteryReleasedItems> GetBatteryReleasedItemById(int id);
        Task AddBatteryReleasedItem(BatteryReleasedItems batteryReleasedItem);
        Task UpdateBatteryReleasedItem(BatteryReleasedItems batteryReleasedItem);
        Task DeleteBatteryReleasedItem(int id);
        Task SaveChangesAsync();
    }
}