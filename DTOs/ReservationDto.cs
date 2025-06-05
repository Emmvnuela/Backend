namespace cantine_univ.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string NomStudent { get; set; } = string.Empty;
        public int MenuId { get; set; }
        public string Plat { get; set; } = string.Empty;
        public DateTime Jour { get; set; }
        public DateTime DateReservation { get; set; }
        public string Statut { get; set; } = "Réservé";
    }
}
