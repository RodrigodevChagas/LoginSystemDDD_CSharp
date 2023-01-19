using System.ComponentModel.DataAnnotations;

namespace SistemaDeLogin.Data.Dtos
{
    public class CreateUsuarioDto
    {
        //Repassar campos criados na classe Usuarios;
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password")]
        public string Repassword { get; set; } = string.Empty;
    }
}
