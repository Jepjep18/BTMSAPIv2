using BTMSAPI.Data;
using BTMSAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BTMSAPI.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentAsync()
        {
            return await _context.Department.ToListAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _context.Department.FindAsync(id);
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _context.Department.AddAsync(department);
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            _context.Department.Update(department);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await GetDepartmentByIdAsync(id);
            if (department != null)
            {
                _context.Department.Remove(department);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}