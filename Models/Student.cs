using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cantine_univ.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string MotDePasseHash { get; set; }

        public string PhotoCarte { get; set; }

        // Navigation
        public ICollection<Reservation> Reservations { get; set; }
    }
}
