namespace BTMSAPI.DTOs
{
    public class CreateUserDto
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }  // Plain password
        public string BusinessUnit { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string? Esignature { get; set; }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
