using BTMSAPI.DTOs;
using BTMSAPI.Models;
using BTMSAPI.Repositories;

namespace BTMSAPI.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentAsync()
        {
            return await _repository.GetAllDepartmentAsync();
        }

        public async Task<Department?> GetDepartmentByIdAsync(int id)
        {
            return await _repository.GetDepartmentByIdAsync(id);
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _repository.AddDepartmentAsync(department);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            _repository.UpdateDepartmentAsync(department);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _repository.DeleteDepartmentAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}