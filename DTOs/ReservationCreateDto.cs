using System;

namespace cantine_univ.DTOs
{
    public class ReservationCreateDto
    {
        public int StudentId { get; set; }
        public int MenuId { get; set; }
        public DateTime DateReservation { get; set; }
    }
}
