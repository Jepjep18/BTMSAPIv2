using System.ComponentModel.DataAnnotations;

namespace BTMSAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Role { get; set; }

        [RegularExpression(@"^\d{6}$", ErrorMessage = "Username must be in the format 000000.")]
        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string BusinessUnit { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string? Esignature { get; set; }
        public int IsActive { get; set; } = 1;
        public DateTime? DateCreated { get; set; }

    }
}
