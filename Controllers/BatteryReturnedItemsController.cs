using BTMSAPI.Models;
using BTMSAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteryReturnedItemsController : ControllerBase
    {
        private readonly IBatteryReturnedItemsService _batteryReturnedItemsService;

        public BatteryReturnedItemsController(IBatteryReturnedItemsService batteryReturnedItemsService)
        {
            _batteryReturnedItemsService = batteryReturnedItemsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatteryReturnedItems>>> GetAllBatteryReturnedItems()
        {
            var batteryReturnedItems = await _batteryReturnedItemsService.GetAllBatteryReturnedItems();
            return Ok(batteryReturnedItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BatteryReturnedItems>> GetBatteryReturnedItemById(int id)
        {
            var batteryReturnedItem = await _batteryReturnedItemsService.GetBatteryReturnedItemById(id);
            if (batteryReturnedItem == null)
            {
                return NotFound();
            }
            return Ok(batteryReturnedItem);
        }

        [HttpPost]
        public async Task<ActionResult> AddBatteryReturnedItem([FromBody] BatteryReturnedItems batteryReturnedItem)
        {
            await _batteryReturnedItemsService.AddBatteryReturnedItem(batteryReturnedItem);
            return CreatedAtAction(nameof(GetBatteryReturnedItemById), new { id = batteryReturnedItem.Id }, batteryReturnedItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBatteryReturnedItem(int id, [FromBody] BatteryReturnedItems batteryReturnedItem)
        {
            if (id != batteryReturnedItem.Id)
            {
                return BadRequest();
            }

            await _batteryReturnedItemsService.UpdateBatteryReturnedItem(batteryReturnedItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBatteryReturnedItem(int id)
        {
            await _batteryReturnedItemsService.DeleteBatteryReturnedItem(id);
            return NoContent();
        }
    }
}