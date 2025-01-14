using BTMSAPI.Data;
using BTMSAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Repositories
{
    public class BatteryItemRepository : IBatteryItemRepository
    {
        private readonly ApplicationDbContext _context;

        public BatteryItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BatteryItem>> GetAllBatteryItems()
        {
            return await _context.BatteryItems.ToListAsync();
        }

        public async Task<BatteryItem> GetBatteryItemById(int id)
        {
            return await _context.BatteryItems.FindAsync(id);
        }

        public async Task AddBatteryItem(BatteryItem batteryItem)
        {
            await _context.BatteryItems.AddAsync(batteryItem);
            await SaveChangesAsync();
        }

        public async Task DeleteBatteryItem(int id)
        {
            var batteryItem = await GetBatteryItemById(id);
            if (batteryItem != null)
            {
                _context.BatteryItems.Remove(batteryItem);
                await SaveChangesAsync();
            }
        }

        public async Task UpdateBatteryItem(BatteryItem batteryItem)
        {
            _context.BatteryItems.Update(batteryItem);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}