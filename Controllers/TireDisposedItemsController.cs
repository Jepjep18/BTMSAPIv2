using BTMSAPI.Models;
using BTMSAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TireDisposedItemsController : ControllerBase
    {
        private readonly ITireDisposedItemsService _tireDisposedItemsService;

        public TireDisposedItemsController(ITireDisposedItemsService tireDisposedItemsService)
        {
            _tireDisposedItemsService = tireDisposedItemsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TireDisposedItems>>> GetAllTireDisposedItems()
        {
            var tireDisposedItems = await _tireDisposedItemsService.GetAllTireDisposedItems();
            return Ok(tireDisposedItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TireDisposedItems>> GetTireDisposedItemById(int id)
        {
            var tireDisposedItem = await _tireDisposedItemsService.GetTireDisposedItemById(id);
            if (tireDisposedItem == null)
            {
                return NotFound();
            }
            return Ok(tireDisposedItem);
        }

        [HttpPost]
        public async Task<ActionResult> AddTireDisposedItem([FromBody] TireDisposedItems tireDisposedItem)
        {
            await _tireDisposedItemsService.AddTireDisposedItem(tireDisposedItem);
            return CreatedAtAction(nameof(GetTireDisposedItemById), new { id = tireDisposedItem.Id }, tireDisposedItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTireDisposedItem(int id, [FromBody] TireDisposedItems tireDisposedItem)
        {
            if (id != tireDisposedItem.Id)
            {
                return BadRequest();
            }

            await _tireDisposedItemsService.UpdateTireDisposedItem(tireDisposedItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTireDisposedItem(int id)
        {
            await _tireDisposedItemsService.DeleteTireDisposedItem(id);
            return NoContent();
        }
    }
}