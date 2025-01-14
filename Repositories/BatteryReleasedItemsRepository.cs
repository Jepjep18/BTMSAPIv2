using BTMSAPI.Data;
using BTMSAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Repositories
{
    public class BatteryReleasedItemsRepository : IBatteryReleasedItemsRepository
    {
        private readonly ApplicationDbContext _context;

        public BatteryReleasedItemsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BatteryReleasedItems>> GetAllBatteryReleasedItems()
        {
            return await _context.BatteryReleasedItems.Include(b => b.BatteryItem).ToListAsync();
        }

        public async Task<BatteryReleasedItems> GetBatteryReleasedItemById(int id)
        {
            return await _context.BatteryReleasedItems.Include(b => b.BatteryItem).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddBatteryReleasedItem(BatteryReleasedItems batteryReleasedItem)
        {
            await _context.BatteryReleasedItems.AddAsync(batteryReleasedItem);
            await SaveChangesAsync();
        }

        public async Task UpdateBatteryReleasedItem(BatteryReleasedItems batteryReleasedItem)
        {
            _context.BatteryReleasedItems.Update(batteryReleasedItem);
            await SaveChangesAsync();
        }

        public async Task DeleteBatteryReleasedItem(int id)
        {
            var batteryReleasedItem = await GetBatteryReleasedItemById(id);
            if (batteryReleasedItem != null)
            {
                _context.BatteryReleasedItems.Remove(batteryReleasedItem);
                await SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}