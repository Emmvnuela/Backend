using System;
using System.ComponentModel.DataAnnotations;

namespace cantine_univ.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [Required]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        [Required]
        public DateTime DateReservation { get; set; }

        public string Statut { get; set; } = "Réservé";
    }
}
