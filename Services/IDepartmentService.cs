using BTMSAPI.Models;

namespace BTMSAPI.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetAllDepartmentAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task AddDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int id);
        Task UpdateDepartmentAsync(Department department);
    }
}
