using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeLogin.ApplicationIdentity.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string username = "")
        {
            Username = username;
        }
        [Key]
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
    }
}
