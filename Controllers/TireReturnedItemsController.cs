using BTMSAPI.Models;
using BTMSAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TireReturnedItemsController : ControllerBase
    {
        private readonly ITireReturnedItemsService _tireReturnedItemsService;

        public TireReturnedItemsController(ITireReturnedItemsService tireReturnedItemsService)
        {
            _tireReturnedItemsService = tireReturnedItemsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TireReturnedItems>>> GetAllTireReturnedItems()
        {
            var tireReturnedItems = await _tireReturnedItemsService.GetAllTireReturnedItems();
            return Ok(tireReturnedItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TireReturnedItems>> GetTireReturnedItemById(int id)
        {
            var tireReturnedItem = await _tireReturnedItemsService.GetTireReturnedItemById(id);
            if (tireReturnedItem == null)
            {
                return NotFound();
            }
            return Ok(tireReturnedItem);
        }

        [HttpPost]
        public async Task<ActionResult> AddTireReturnedItem([FromBody] TireReturnedItems tireReturnedItem)
        {
            await _tireReturnedItemsService.AddTireReturnedItem(tireReturnedItem);
            return CreatedAtAction(nameof(GetTireReturnedItemById), new { id = tireReturnedItem.Id }, tireReturnedItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTireReturnedItem(int id, [FromBody] TireReturnedItems tireReturnedItem)
        {
            if (id != tireReturnedItem.Id)
            {
                return BadRequest();
            }

            await _tireReturnedItemsService.UpdateTireReturnedItem(tireReturnedItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTireReturnedItem(int id)
        {
            await _tireReturnedItemsService.DeleteTireReturnedItem(id);
            return NoContent();
        }
    }
}