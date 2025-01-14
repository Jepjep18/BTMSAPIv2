using BTMSAPI.Models;
using BTMSAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteryReleasedItemsController : ControllerBase
    {
        private readonly IBatteryReleasedItemsService _batteryReleasedItemsService;

        public BatteryReleasedItemsController(IBatteryReleasedItemsService batteryReleasedItemsService)
        {
            _batteryReleasedItemsService = batteryReleasedItemsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatteryReleasedItems>>> GetAllBatteryReleasedItems()
        {
            var batteryReleasedItems = await _batteryReleasedItemsService.GetAllBatteryReleasedItems();
            return Ok(batteryReleasedItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BatteryReleasedItems>> GetBatteryReleasedItemById(int id)
        {
            var batteryReleasedItem = await _batteryReleasedItemsService.GetBatteryReleasedItemById(id);
            if (batteryReleasedItem == null)
            {
                return NotFound();
            }
            return Ok(batteryReleasedItem);
        }

        [HttpPost]
        public async Task<ActionResult> AddBatteryReleasedItem([FromBody] BatteryReleasedItems batteryReleasedItem)
        {
            await _batteryReleasedItemsService.AddBatteryReleasedItem(batteryReleasedItem);
            return CreatedAtAction(nameof(GetBatteryReleasedItemById), new { id = batteryReleasedItem.Id }, batteryReleasedItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBatteryReleasedItem(int id, [FromBody] BatteryReleasedItems batteryReleasedItem)
        {
            if (id != batteryReleasedItem.Id)
            {
                return BadRequest();
            }

            await _batteryReleasedItemsService.UpdateBatteryReleasedItem(batteryReleasedItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBatteryReleasedItem(int id)
        {
            await _batteryReleasedItemsService.DeleteBatteryReleasedItem(id);
            return NoContent();
        }
    }
}