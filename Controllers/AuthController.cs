using BTMSAPI.DTOs;
using BTMSAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BTMSAPI.Utils;


namespace BTMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthController(IUserService userService, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userService = userService;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userService.GetUserByUsernameAsync(loginDto.Username);
            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }

            // Add debug logging
            Console.WriteLine($"Stored hash: {user.PasswordHash}");
            Console.WriteLine($"Attempting to verify password");

            try
            {
                bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash);
                Console.WriteLine($"Password verification result: {isPasswordValid}");

                if (isPasswordValid)
                {
                    var token = _jwtTokenGenerator.GenerateToken(user);
                    return Ok(new { Token = token });
                }
            }
            catch (BCrypt.Net.SaltParseException ex)
            {
                Console.WriteLine($"BCrypt error: {ex.Message}");
                // Log the error here if you have logging configured
            }

            return Unauthorized(new { Message = "Invalid username or password" });
        }



    }
}
