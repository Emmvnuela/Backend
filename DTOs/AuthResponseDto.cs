namespace cantine_univ.DTOs
{
    public class AuthResponseDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }  // Pour JWT si tu veux l'ajouter
    }
}
