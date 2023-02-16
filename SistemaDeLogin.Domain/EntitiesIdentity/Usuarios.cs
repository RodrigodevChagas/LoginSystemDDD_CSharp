using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeLogin.Domain.EntitiesIdentity
{
    public class Usuarios
    {
        [Key]
        [Required]
        [Display(Name = "Código")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [NotMapped]
        public IFormFile? ProfilePicFile { get; set; }
        
        [NotMapped]
        public IFormFile? CoverPicFile { get; set; }
       
        public string CoverPic { get; set; } = string.Empty;
        public string ProfilePic { get; set; } = string.Empty;
    }
}
