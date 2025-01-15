using System.Collections.Generic;
using System.Linq;
using BTMSAPI.Data;
using BTMSAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BTMSAPI.Services
{
    public class TireItemService : ITireItemService
    {
        private readonly ApplicationDbContext _context;

        public TireItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TireItem> GetAllTireItems()
        {
            return _context.TireItems.ToList(); 
        }

        public TireItem GetTireItemById(int id)
        {
            return _context.TireItems.FirstOrDefault(t => t.Id == id); 
        }

        public void CreateTireItem(TireItem newTireItem)
        {
            newTireItem.Status = "PENDING"; 
            _context.TireItems.Add(newTireItem); 
            _context.SaveChanges(); 
        }

        public void UpdateTireItem(TireItem updatedTireItem)
        {
            var existingTireItem = _context.TireItems.FirstOrDefault(t => t.Id == updatedTireItem.Id);
            if (existingTireItem != null)
            {
                existingTireItem.DateReceived = updatedTireItem.DateReceived;
                existingTireItem.Receivedby = updatedTireItem.Receivedby;
                existingTireItem.DrciNo = updatedTireItem.DrciNo;
                existingTireItem.PoNo = updatedTireItem.PoNo;
                existingTireItem.Supplier = updatedTireItem.Supplier;
                existingTireItem.ItemCode = updatedTireItem.ItemCode;
                existingTireItem.Quantity = updatedTireItem.Quantity;
                existingTireItem.Unitofmeasurement = updatedTireItem.Unitofmeasurement;
                existingTireItem.Tiresize = updatedTireItem.Tiresize;
                existingTireItem.Tirebrand = updatedTireItem.Tirebrand;
                existingTireItem.TireSerial = updatedTireItem.TireSerial;
                existingTireItem.DebossedNo = updatedTireItem.DebossedNo;
                existingTireItem.Remarks = updatedTireItem.Remarks;
                existingTireItem.Status = updatedTireItem.Status;
                existingTireItem.TireType = updatedTireItem.TireType;
                existingTireItem.NewSerialNo = updatedTireItem.NewSerialNo;
                existingTireItem.ItemCategory = updatedTireItem.ItemCategory;

                _context.SaveChanges(); 
            }
        }

        public void DeleteTireItem(int id)
        {
            var tireItem = _context.TireItems.FirstOrDefault(t => t.Id == id);
            if (tireItem != null)
            {
                _context.TireItems.Remove(tireItem); 
                _context.SaveChanges(); 
            }
        }
    }
}
