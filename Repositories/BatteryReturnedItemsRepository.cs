using BTMSAPI.Data;
using BTMSAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Repositories
{
    public class BatteryReturnedItemsRepository : IBatteryReturnedItemsRepository
    {
        private readonly ApplicationDbContext _context;


        public BatteryReturnedItemsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BatteryReturnedItems>> GetAllBatteryReturnedItems()
        {
            return await _context.BatteryReturnedItems.Include(b => b.BatteryReleasedItem).ToListAsync();
        }

        public async Task<BatteryReturnedItems> GetBatteryReturnedItemById(int id)
        {
            return await _context.BatteryReturnedItems.Include(b => b.BatteryReleasedItem).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddBatteryReturnedItem(BatteryReturnedItems batteryReturnedItem)
        {
            await _context.BatteryReturnedItems.AddAsync(batteryReturnedItem);
            await SaveChangesAsync();
        }

        public async Task UpdateBatteryReturnedItem(BatteryReturnedItems batteryReturnedItem)
        {
            _context.BatteryReturnedItems.Update(batteryReturnedItem);
            await SaveChangesAsync();
        }

        public async Task DeleteBatteryReturnedItem(int id)
        {
            var batteryReturnedItem = await GetBatteryReturnedItemById(id);
            if (batteryReturnedItem != null)
            {
                _context.BatteryReturnedItems.Remove(batteryReturnedItem);
                await SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}