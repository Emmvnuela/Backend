using Microsoft.AspNetCore.Mvc;
using cantine_univ.Services;
using cantine_univ.DTOs;

namespace cantine_univ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationCreateDto dto)
        {
            var result = await _reservationService.CreateReservationAsync(dto);
            return Ok(result);
        }

        [HttpPost("cancel/{id}")]
        public async Task<IActionResult> CancelReservation(int id)
        {
            var result = await _reservationService.CancelReservationAsync(id);
            return Ok(result);
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetReservationsByStudent(int studentId)
        {
            var reservations = await _reservationService.GetReservationsByStudentAsync(studentId);
            return Ok(reservations);
        }
    }
}
