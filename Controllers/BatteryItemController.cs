using BTMSAPI.DTOs;
using BTMSAPI.Models;
using BTMSAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatteryItemController : ControllerBase
    {
        private readonly IBatteryItemService _batteryItemService;

        public BatteryItemController(IBatteryItemService batteryItemService)
        {
            _batteryItemService = batteryItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BatteryItem>>> GetAllBatteryItems()
        {
            var batteryItems = await _batteryItemService.GetAllBatteryItems();
            return Ok(batteryItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BatteryItem>> GetBatteryItemById(int id)
        {
            var batteryItem = await _batteryItemService.GetBatteryItemById(id);
            if (batteryItem == null)
            {
                return NotFound();
            }
            return Ok(batteryItem);
        }

        [HttpPost]
        public async Task<ActionResult> AddBatteryItem([FromBody] BatteryItemDTO batteryItemDTO)
        {
            await _batteryItemService.AddBatteryItem(batteryItemDTO);
            return CreatedAtAction(nameof(GetBatteryItemById), new { id = batteryItemDTO.Id }, batteryItemDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBatteryItem(int id, [FromBody] BatteryItem batteryItem)
        {
            if (id != batteryItem.Id)
            {
                return BadRequest();
            }

            await _batteryItemService.UpdateBatteryItem(batteryItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBatteryItem(int id)
        {
            await _batteryItemService.DeleteBatteryItem(id);
            return NoContent();
        }
    }
}