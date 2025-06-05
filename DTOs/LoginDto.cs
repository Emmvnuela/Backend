using System.ComponentModel.DataAnnotations;

namespace cantine_univ.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Numero { get; set; }

        [Required]
        public string MotDePasse { get; set; }
    }
}
