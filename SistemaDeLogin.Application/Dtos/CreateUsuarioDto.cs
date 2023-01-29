using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeLogin.AplicationIdentity.Dtos;

public class CreateUsuarioDto
{
    [Column("Nome")]
    [Display(Name = "Nome")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please, type your username!")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please, type your Email!")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please, type your password!")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    
    [Compare("Password")]
    [Required(ErrorMessage = "Please, retype your password!")]
    public string Repassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please, type your phone number!")]
    public string PhoneNumber { get; set; } = string.Empty;
}
