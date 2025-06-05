using System.ComponentModel.DataAnnotations;

namespace cantine_univ.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Nom { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string MotDePasse { get; set; }

        public string PhotoCarte { get; set; }
    }
}
