using System.ComponentModel.DataAnnotations;

namespace SistemaDeLogin.AplicationIdentity.Requests
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Please, type your username!")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please, type your password!")]
        public string? Password { get; set; }
    }
}
