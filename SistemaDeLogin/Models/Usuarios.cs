using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeLogin.Models
{
    [Table("Login")]
    public class Usuarios
    {
        //Criando Model, declarando quais dados serão passados e aplicando encapsulamento.
        //Adicionar campos que quero preenchido. Ex: Email, Telefone.
        //Repassar campos para CreateUsuarioDto;
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Código")]
        public int Id { get; set; }
        
        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; } = string.Empty;
        
        [Column("Username")]
        [Display(Name = "Username")]
        public string Username { get; set; } = string.Empty;
    }
}
