using BTMSAPI.Models;
using BTMSAPI.DTOs;

namespace BTMSAPI.Services
{
    public interface IBatteryItemService
    {
        Task<IEnumerable<BatteryItem>> GetAllBatteryItems();
        Task<BatteryItem> GetBatteryItemById(int id);
        Task AddBatteryItem(BatteryItemDTO batteryItemDTO);
        Task DeleteBatteryItem(int id);
        Task UpdateBatteryItem(BatteryItem batteryItem);
    }
}