using BTMSAPI.DTOs;
using BTMSAPI.Models;
using BTMSAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Services
{
    public class BatteryItemService : IBatteryItemService
    {
        private readonly IBatteryItemRepository _repository;

        public BatteryItemService(IBatteryItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BatteryItem>> GetAllBatteryItems()
        {
            return await _repository.GetAllBatteryItems();
        }

        public async Task<BatteryItem?> GetBatteryItemById(int id)
        {
            return await _repository.GetBatteryItemById(id);
        }

        public async Task AddBatteryItem(BatteryItemDTO batteryItemDTO)
        {
            var batteryItem = new BatteryItem
            {
                DateReceived = DateTime.UtcNow,
                Receivedby = batteryItemDTO.Receivedby,
                DrsiNo = batteryItemDTO.DrsiNo,
                PoNo = batteryItemDTO.PoNo,
                ItemCode = batteryItemDTO.ItemCode,
                Supplier = batteryItemDTO.Supplier,
                ItemDescription = batteryItemDTO.ItemDescription,
                Quantity = batteryItemDTO.Quantity,
                Unitofmeasurement = batteryItemDTO.Unitofmeasurement,
                Batteryserial = batteryItemDTO.Batteryserial,
                DebossedNo = batteryItemDTO.DebossedNo,
                Status = "PENDING",
                ItemCategory = "Battery"
            };

            await _repository.AddBatteryItem(batteryItem);
        }

        public async Task DeleteBatteryItem(int id)
        {
            await _repository.DeleteBatteryItem(id);
        }

        public async Task UpdateBatteryItem(BatteryItem batteryItem)
        {
            var existingBattery = await _repository.GetBatteryItemById(batteryItem.Id);
            if (existingBattery == null)
            {
                throw new KeyNotFoundException("Battery Item not found");
            }

            existingBattery.Receivedby = batteryItem.Receivedby;
            existingBattery.DrsiNo = batteryItem.DrsiNo;
            existingBattery.PoNo = batteryItem.PoNo;
            existingBattery.ItemCode = batteryItem.ItemCode;
            existingBattery.Supplier = batteryItem.Supplier;
            existingBattery.ItemDescription = batteryItem.ItemDescription;
            existingBattery.Quantity = batteryItem.Quantity;
            existingBattery.Unitofmeasurement = batteryItem.Unitofmeasurement;
            existingBattery.Batteryserial = batteryItem.Batteryserial;
            existingBattery.DebossedNo = batteryItem.DebossedNo;
            existingBattery.Status = batteryItem.Status;
            existingBattery.ItemCategory = batteryItem.ItemCategory;

            await _repository.UpdateBatteryItem(existingBattery);
        }
    }
}