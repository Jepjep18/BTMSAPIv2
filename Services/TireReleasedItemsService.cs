using System.Collections.Generic;
using System.Linq;
using BTMSAPI.Data;
using BTMSAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BTMSAPI.Services
{
    public class TireReleasedItemsService : ITireReleasedItemsService
    {
        private readonly ApplicationDbContext _context;

        public TireReleasedItemsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TireReleasedItems>> GetAllTireReleasedItems()
        {
            return await _context.TireReleasedItems.Include(t => t.TireItem).ToListAsync();
        }

        public async Task<TireReleasedItems> GetTireReleasedItemById(int id)
        {
            return await _context.TireReleasedItems.Include(t => t.TireItem).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTireReleasedItem(TireReleasedItems tireReleasedItem)
        {
            // Update the status of the TireItem to "RELEASED"
            var tireItem = await _context.TireItems.FirstOrDefaultAsync(t => t.Id == tireReleasedItem.TireItemId);
            if (tireItem != null)
            {
                tireItem.Status = "RELEASED";
                _context.TireItems.Update(tireItem);
            }

            await _context.TireReleasedItems.AddAsync(tireReleasedItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTireReleasedItem(TireReleasedItems tireReleasedItem)
        {
            var existingTireReleasedItem = await _context.TireReleasedItems.FirstOrDefaultAsync(t => t.Id == tireReleasedItem.Id);
            if (existingTireReleasedItem != null)
            {
                existingTireReleasedItem.BusinessUnit = tireReleasedItem.BusinessUnit;
                existingTireReleasedItem.Imjno = tireReleasedItem.Imjno;
                existingTireReleasedItem.Driver = tireReleasedItem.Driver;
                existingTireReleasedItem.PlateNo = tireReleasedItem.PlateNo;
                existingTireReleasedItem.Abfiserialno = tireReleasedItem.Abfiserialno;
                existingTireReleasedItem.Remarks = tireReleasedItem.Remarks;
                existingTireReleasedItem.ReleaseDate = tireReleasedItem.ReleaseDate;
                existingTireReleasedItem.Receivedby = tireReleasedItem.Receivedby;
                existingTireReleasedItem.TireItemId = tireReleasedItem.TireItemId;
                existingTireReleasedItem.OldSnDebossedNo = tireReleasedItem.OldSnDebossedNo;

                _context.TireReleasedItems.Update(existingTireReleasedItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTireReleasedItem(int id)
        {
            var tireReleasedItem = await _context.TireReleasedItems.FirstOrDefaultAsync(t => t.Id == id);
            if (tireReleasedItem != null)
            {
                _context.TireReleasedItems.Remove(tireReleasedItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}