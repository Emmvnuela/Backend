using System.Collections.Generic;
using System.Threading.Tasks;
using cantine_univ.DTOs;

namespace cantine_univ.Services
{
    public interface IReservationService
    {
        Task<ReservationDto> CreateReservationAsync(ReservationCreateDto dto);
        Task<ReservationDto> CancelReservationAsync(int reservationId);
        Task<List<ReservationDto>> GetReservationsByStudentAsync(int etudiantId);
    }
}
