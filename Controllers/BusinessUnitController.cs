using Microsoft.AspNetCore.Mvc;
using BTMSAPI.DTOs;
using BTMSAPI.Models;
using BTMSAPI.Services;

namespace BTMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessUnitController : ControllerBase
    {
        private readonly IBusinessUnitService _businessUnitService;

        public BusinessUnitController(IBusinessUnitService businessUnitService)
        {
            _businessUnitService = businessUnitService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessUnit>>> GetAllBusinessUnits()
        {
            var businessUnits = await _businessUnitService.GetAllBusinessUnitAsync();
            return Ok(businessUnits);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessUnit?>> GetBusinessUnitById(int id)
        {
            var businessUnit = await _businessUnitService.GetBusinessUnitByIdAsync(id);
            if (businessUnit == null)
            {
                return NotFound();
            }
            return Ok(businessUnit);
        }

        [HttpPost]
        public async Task<ActionResult> AddBusinessUnit(BusinessUnitDTO businessUnitDTO)
        {
            await _businessUnitService.AddBusinessUnitAsync(businessUnitDTO);
            return CreatedAtAction(nameof(GetBusinessUnitById), new { id = businessUnitDTO.Id }, businessUnitDTO);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBusinessUnit(int id, BusinessUnit businessUnit)
        {
            if (id != businessUnit.Id)
            {
                return BadRequest("ID mismatch");
            }

            var existingBusinessUnit = await _businessUnitService.GetBusinessUnitByIdAsync(id);
            if (existingBusinessUnit == null)
            {
                return NotFound();
            }

            await _businessUnitService.UpdateBusinessUnitAsync(businessUnit);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBusinessUnit(int id)
        {
            var existingBusinessUnit = await _businessUnitService.GetBusinessUnitByIdAsync(id);
            if (existingBusinessUnit == null)
            {
                return NotFound();
            }

            await _businessUnitService.DeleteBusinessUnitAsync(id);
            return NoContent();
        }
    }
}