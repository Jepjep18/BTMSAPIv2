using Microsoft.AspNetCore.Mvc;
using BTMSAPI.Models;
using BTMSAPI.Services;
using System.Collections.Generic;

namespace BTMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TireItemController : ControllerBase
    {
        private readonly ITireItemService _tireItemService;

        public TireItemController(ITireItemService tireItemService)
        {
            _tireItemService = tireItemService;
        }

        [HttpPost]
        public ActionResult<TireItem> CreateTireItem([FromBody] TireItem tireItem)
        {
            if (tireItem == null)
            {
                return BadRequest("TireItem cannot be null.");
            }

            tireItem.Status = "PENDING";
            _tireItemService.CreateTireItem(tireItem);

            return CreatedAtAction(nameof(GetTireItemById), new { id = tireItem.Id }, tireItem);
        }

        [HttpGet]
        public ActionResult<IEnumerable<TireItem>> GetAllTireItems()
        {
            var tireItems = _tireItemService.GetAllTireItems();
            return Ok(tireItems);
        }

        [HttpGet("{id}")]
        public ActionResult<TireItem> GetTireItemById(int id)
        {
            var tireItem = _tireItemService.GetTireItemById(id);
            if (tireItem == null)
            {
                return NotFound();
            }
            return Ok(tireItem);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTireItem(int id, [FromBody] TireItem updatedTireItem)
        {
            if (updatedTireItem == null || updatedTireItem.Id != id)
            {
                return BadRequest("TireItem is null or ID mismatch.");
            }

            var existingTireItem = _tireItemService.GetTireItemById(id);
            if (existingTireItem == null)
            {
                return NotFound();
            }

            _tireItemService.UpdateTireItem(updatedTireItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTireItem(int id)
        {
            var tireItem = _tireItemService.GetTireItemById(id);
            if (tireItem == null)
            {
                return NotFound();
            }

            _tireItemService.DeleteTireItem(id);
            return NoContent();
        }
    }
}