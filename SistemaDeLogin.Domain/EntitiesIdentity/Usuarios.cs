
using System.ComponentModel.DataAnnotations;

namespace SistemaDeLogin.Domain.EntitiesIdentity
{
    public class Usuarios
    {
        [Key]
        [Required]
        [Display(Name = "Código")]
        public int Id { get; set; }
        
        [Display(Name = "Nome")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; } = string.Empty;

        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Repassword")]
        public string Repassword { get; set; } = string.Empty;
    }
}
