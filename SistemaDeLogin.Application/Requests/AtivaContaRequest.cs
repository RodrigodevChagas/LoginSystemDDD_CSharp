using System.ComponentModel.DataAnnotations;

namespace SistemaDeLogin.Data.Requests
{
    public class AtivaContaRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? CodigoDeAtivacao { get; set; }
    }
}
