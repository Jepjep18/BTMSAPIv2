using BTMSAPI.Models;

namespace BTMSAPI.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
        Task SaveChangesAsync();
    }
}
