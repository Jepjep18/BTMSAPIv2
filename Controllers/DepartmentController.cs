using BTMSAPI.DTOs;
using BTMSAPI.Models;
using BTMSAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BTMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetAllDepartmentAsync()
        {
            var departments = await _departmentService.GetAllDepartmentAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department?>> GetDepartmentByIdAsync(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> AddDepartment(CreateDepartmentDTO departmentDTO)
        {
            var department = new Department
            {
                DepartmentName = departmentDTO.DepartmentName,
                DepartmentCode = departmentDTO.DepartmentCode
            };

            await _departmentService.AddDepartmentAsync(department);
            return CreatedAtAction(nameof(GetDepartmentByIdAsync), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentDTO departmentDTO)
        {
            if (id != departmentDTO.Id)
            {
                return BadRequest("Department ID mismatch.");
            }

            var existingDepartment = await _departmentService.GetDepartmentByIdAsync(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }

            existingDepartment.DepartmentName = departmentDTO.DepartmentName;
            existingDepartment.DepartmentCode = departmentDTO.DepartmentCode;

            await _departmentService.UpdateDepartmentAsync(existingDepartment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var existingDepartment = await _departmentService.GetDepartmentByIdAsync(id);
            if (existingDepartment == null)
            {
                return NotFound();
            }

            await _departmentService.DeleteDepartmentAsync(id);
            return NoContent();
        }
    }
}