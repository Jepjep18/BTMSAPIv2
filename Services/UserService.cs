using BTMSAPI.Models;
using BTMSAPI.Repositories;
using BCrypt.Net;
using BTMSAPI.DTOs;


namespace BTMSAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }

        public async Task CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Firstname = createUserDto.Firstname,
                Middlename = createUserDto.Middlename,
                Lastname = createUserDto.Lastname,
                Role = createUserDto.Role,
                Username = createUserDto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password), // Hash the plain password
                BusinessUnit = createUserDto.BusinessUnit,
                Department = createUserDto.Department,
                Position = createUserDto.Position,
                Esignature = createUserDto.Esignature,
                DateCreated = DateTime.UtcNow
            };

            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
            await _userRepository.SaveChangesAsync();
        }

        public Task UpdatePasswordAsync(int userId, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
