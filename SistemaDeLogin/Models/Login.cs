using System.ComponentModel.DataAnnotations;

namespace SistemaDeLogin.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Please, type your username!")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please, type your password!")]
        public string? Password { get; set; }
    }
}
