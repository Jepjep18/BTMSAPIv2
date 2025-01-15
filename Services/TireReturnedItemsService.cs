using BTMSAPI.Data;
using BTMSAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Services
{
    public class TireReturnedItemsService : ITireReturnedItemsService
    {
        private readonly ApplicationDbContext _context;

        public TireReturnedItemsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TireReturnedItems>> GetAllTireReturnedItems()
        {
            return await _context.TireReturnedItems.Include(t => t.TireReleasedItems).ToListAsync();
        }

        public async Task<TireReturnedItems> GetTireReturnedItemById(int id)
        {
            return await _context.TireReturnedItems.Include(t => t.TireReleasedItems).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTireReturnedItem(TireReturnedItems tireReturnedItem)
        {
            // Update the status of the TireItem to "RETURNED"
            var tireReleasedItem = await _context.TireReleasedItems.FirstOrDefaultAsync(t => t.Id == tireReturnedItem.TireReleasedId);
            if (tireReleasedItem != null)
            {
                var tireItem = await _context.TireItems.FirstOrDefaultAsync(t => t.Id == tireReleasedItem.TireItemId);
                if (tireItem != null)
                {
                    tireItem.Status = "RETURNED";
                    _context.TireItems.Update(tireItem);
                }
            }

            await _context.TireReturnedItems.AddAsync(tireReturnedItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTireReturnedItem(TireReturnedItems tireReturnedItem)
        {
            var existingTireReturnedItem = await _context.TireReturnedItems.FirstOrDefaultAsync(t => t.Id == tireReturnedItem.Id);
            if (existingTireReturnedItem != null)
            {
                existingTireReturnedItem.ReceivedDate = tireReturnedItem.ReceivedDate;
                existingTireReturnedItem.EndorsedBy = tireReturnedItem.EndorsedBy;
                existingTireReturnedItem.Purpose = tireReturnedItem.Purpose;
                existingTireReturnedItem.TireReleasedId = tireReturnedItem.TireReleasedId;

                _context.TireReturnedItems.Update(existingTireReturnedItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTireReturnedItem(int id)
        {
            var tireReturnedItem = await _context.TireReturnedItems.FirstOrDefaultAsync(t => t.Id == id);
            if (tireReturnedItem != null)
            {
                _context.TireReturnedItems.Remove(tireReturnedItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}