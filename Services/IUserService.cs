using BTMSAPI.DTOs;
using BTMSAPI.Models;

namespace BTMSAPI.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task CreateUserAsync(CreateUserDto createUserDto);
        Task UpdateUserAsync(User user);
        Task UpdatePasswordAsync(int userId, string newPassword);
        Task DeleteUserAsync(int id);
    }
}
