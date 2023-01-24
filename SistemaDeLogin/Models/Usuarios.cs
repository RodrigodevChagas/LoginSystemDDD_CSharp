
using System.ComponentModel.DataAnnotations;

namespace SistemaDeLogin.Models
{
    public class Usuarios
    {
        //Criando Model, declarando quais dados serão passados e aplicando encapsulamento.
        //Adicionar campos que quero preenchido. Ex: Email, Telefone.
        //Repassar campos para CreateUsuarioDto;
        [Key]
        [Required]
        [Display(Name = "Código")]
        public int Id { get; set; }
        
        [Display(Name = "Nome")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Looks like you forgort the username!")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Looks like you forgort the username!")]
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
