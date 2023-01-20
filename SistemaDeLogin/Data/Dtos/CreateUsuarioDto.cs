using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeLogin.Data.Dtos
{
    public class CreateUsuarioDto
    {
        //Repassar campos criados na classe Usuarios;

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Name { get; set; } = string.Empty;

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

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
