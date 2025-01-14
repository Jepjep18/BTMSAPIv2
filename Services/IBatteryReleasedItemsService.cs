using BTMSAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Services
{
    public interface IBatteryReleasedItemsService
    {
        Task<IEnumerable<BatteryReleasedItems>> GetAllBatteryReleasedItems();
        Task<BatteryReleasedItems> GetBatteryReleasedItemById(int id);
        Task AddBatteryReleasedItem(BatteryReleasedItems batteryReleasedItem);
        Task UpdateBatteryReleasedItem(BatteryReleasedItems batteryReleasedItem);
        Task DeleteBatteryReleasedItem(int id);
    }
}