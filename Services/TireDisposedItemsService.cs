using BTMSAPI.Data;
using BTMSAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BTMSAPI.Services
{
    public class TireDisposedItemsService : ITireDisposedItemsService
    {
        private readonly ApplicationDbContext _context;

        public TireDisposedItemsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TireDisposedItems>> GetAllTireDisposedItems()
        {
            return await _context.TireDisposedItems.ToListAsync();
        }

        public async Task<TireDisposedItems> GetTireDisposedItemById(int id)
        {
            return await _context.TireDisposedItems.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTireDisposedItem(TireDisposedItems tireDisposedItem)
        {
            // Set the DisposalStatus to "PENDING"
            tireDisposedItem.DisposalStatus = "PENDING";

            // Split the TireReturnIds and update the status of each TireReturnedItem to "DISPOSED"
            var tireReturnIds = tireDisposedItem.TireReturnIds.Split(',').Select(int.Parse).ToList();
            foreach (var tireReturnId in tireReturnIds)
            {
                var tireReturnedItem = await _context.TireReturnedItems
                    .Include(t => t.TireReleasedItems)
                    .FirstOrDefaultAsync(t => t.Id == tireReturnId);

                if (tireReturnedItem != null && tireReturnedItem.TireReleasedItems != null)
                {
                    // Update the status of the associated TireItem to "DISPOSED"
                    var tireItem = await _context.TireItems.FirstOrDefaultAsync(t => t.Id == tireReturnedItem.TireReleasedItems.TireItemId);
                    if (tireItem != null)
                    {
                        tireItem.Status = "DISPOSED";
                        _context.TireItems.Update(tireItem);
                    }
                }
            }

            await _context.TireDisposedItems.AddAsync(tireDisposedItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTireDisposedItem(TireDisposedItems tireDisposedItem)
        {
            var existingTireDisposedItem = await _context.TireDisposedItems.FirstOrDefaultAsync(t => t.Id == tireDisposedItem.Id);
            if (existingTireDisposedItem != null)
            {
                existingTireDisposedItem.DisposalDate = tireDisposedItem.DisposalDate;
                existingTireDisposedItem.EndorsedBy = tireDisposedItem.EndorsedBy;
                existingTireDisposedItem.DisposalType = tireDisposedItem.DisposalType;
                existingTireDisposedItem.TireReturnIds = tireDisposedItem.TireReturnIds;
                existingTireDisposedItem.DisposalStatus = tireDisposedItem.DisposalStatus;

                _context.TireDisposedItems.Update(existingTireDisposedItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTireDisposedItem(int id)
        {
            var tireDisposedItem = await _context.TireDisposedItems.FirstOrDefaultAsync(t => t.Id == id);
            if (tireDisposedItem != null)
            {
                _context.TireDisposedItems.Remove(tireDisposedItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}