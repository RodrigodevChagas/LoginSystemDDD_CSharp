using System.ComponentModel.DataAnnotations;

namespace SistemaDeLogin.Domain.EntitiesIdentity
{
    public class Login
    {
        [Required(ErrorMessage = "Please, type your username!")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please, type your password!")]
        public string? Password { get; set; }

    }
}
