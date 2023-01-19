using System.ComponentModel.DataAnnotations;

namespace SistemaDeLogin.Data.Requests
{
    public class LoginRequest
    {
        [Required]
        public string? Username { get; set; }
        
        [Required]
        public string? Password { get; set; }
    }
}
