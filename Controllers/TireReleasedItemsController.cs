using BTMSAPI.Models;
using BTMSAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TireReleasedItemsController : ControllerBase
    {
        private readonly ITireReleasedItemsService _tireReleasedItemsService;

        public TireReleasedItemsController(ITireReleasedItemsService tireReleasedItemsService)
        {
            _tireReleasedItemsService = tireReleasedItemsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TireReleasedItems>>> GetAllTireReleasedItems()
        {
            var tireReleasedItems = await _tireReleasedItemsService.GetAllTireReleasedItems();
            return Ok(tireReleasedItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TireReleasedItems>> GetTireReleasedItemById(int id)
        {
            var tireReleasedItem = await _tireReleasedItemsService.GetTireReleasedItemById(id);
            if (tireReleasedItem == null)
            {
                return NotFound();
            }
            return Ok(tireReleasedItem);
        }

        [HttpPost]
        public async Task<ActionResult> AddTireReleasedItem([FromBody] TireReleasedItems tireReleasedItem)
        {
            await _tireReleasedItemsService.AddTireReleasedItem(tireReleasedItem);
            return CreatedAtAction(nameof(GetTireReleasedItemById), new { id = tireReleasedItem.Id }, tireReleasedItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTireReleasedItem(int id, [FromBody] TireReleasedItems tireReleasedItem)
        {
            if (id != tireReleasedItem.Id)
            {
                return BadRequest();
            }

            await _tireReleasedItemsService.UpdateTireReleasedItem(tireReleasedItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTireReleasedItem(int id)
        {
            await _tireReleasedItemsService.DeleteTireReleasedItem(id);
            return NoContent();
        }
    }
}