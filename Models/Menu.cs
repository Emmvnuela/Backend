using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cantine_univ.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Required]
        public string Plat { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Jour { get; set; }

        // Navigation
        public ICollection<Reservation> Reservations { get; set; }
    }
}
