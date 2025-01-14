using BTMSAPI.Models;

namespace BTMSAPI.Repositories
{
    public interface IBatteryItemRepository
    {
        Task<IEnumerable<BatteryItem>> GetAllBatteryItems();
        Task<BatteryItem> GetBatteryItemById(int id);
        Task AddBatteryItem(BatteryItem batteryItem);
        Task DeleteBatteryItem(int id);
        Task UpdateBatteryItem(BatteryItem batteryItem);
        Task SaveChangesAsync();
    }
}