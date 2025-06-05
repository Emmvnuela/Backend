using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cantine_univ.Data;
using cantine_univ.DTOs;
using cantine_univ.Models;
using Microsoft.EntityFrameworkCore;

namespace cantine_univ.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReservationDto> CreateReservationAsync(ReservationCreateDto dto)
        {
            var menu = await _context.Menus.FindAsync(dto.MenuId);
            var student = await _context.Students.FindAsync(dto.StudentId);

            if (menu == null || student == null) return null;

            var reservation = new Reservation
            {
                MenuId = dto.MenuId,
                StudentId = dto.StudentId,
                DateReservation = dto.DateReservation,
                Statut = "Réservé"
            };

            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return new ReservationDto
            {
                Id = reservation.Id,
                StudentId = student.Id,
                NomStudent = student.Nom,
                MenuId = menu.Id,
                Plat = menu.Plat,
                Jour = menu.Jour,
                DateReservation = reservation.DateReservation,
                Statut = reservation.Statut
            };
        }

        public async Task<ReservationDto> CancelReservationAsync(int reservationId)
        {
            var reservation = await _context.Reservations
                .Include(r => r.Student)
                .Include(r => r.Menu)
                .FirstOrDefaultAsync(r => r.Id == reservationId);

            if (reservation == null) return null;

            reservation.Statut = "Annulé";
            await _context.SaveChangesAsync();

            return new ReservationDto
            {
                Id = reservation.Id,
                StudentId = reservation.StudentId,
                NomStudent = reservation.Student.Nom,
                MenuId = reservation.MenuId,
                Plat = reservation.Menu.Plat,
                Jour = reservation.Menu.Jour,
                DateReservation = reservation.DateReservation,
                Statut = reservation.Statut
            };
        }

        public async Task<List<ReservationDto>> GetReservationsByStudentAsync(int studentId)
        {
            return await _context.Reservations
                .Include(r => r.Menu)
                .Include(r => r.Student)
                .Where(r => r.StudentId == studentId)
                .Select(r => new ReservationDto
                {
                    Id = r.Id,
                    StudentId = r.StudentId,
                    NomStudent = r.Student.Nom,
                    MenuId = r.MenuId,
                    Plat = r.Menu.Plat,
                    Jour = r.Menu.Jour,
                    DateReservation = r.DateReservation,
                    Statut = r.Statut
                })
                .ToListAsync();
        }
    }
}
