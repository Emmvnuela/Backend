using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using cantine_univ.DTOs;
using cantine_univ.Models;
using cantine_univ.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace cantine_univ.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public AuthService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Students.AnyAsync(e => e.Email == dto.Email || e.Numero == dto.Numero))
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Email ou numéro déjà utilisé."
                };
            }

            var student = new Student
            {
                Nom = dto.Nom,
                Email = dto.Email,
                Numero = dto.Numero,
                MotDePasseHash = BCrypt.Net.BCrypt.HashPassword(dto.MotDePasse),
                PhotoCarte = dto.PhotoCarte
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Success = true,
                Message = "Inscription réussie."
            };
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
        {
            var student = await _context.Students.FirstOrDefaultAsync(e => e.Numero == dto.Numero);
            if (student == null || !BCrypt.Net.BCrypt.Verify(dto.MotDePasse, student.MotDePasseHash))
            {
                return new AuthResponseDto
                {
                    Success = false,
                    Message = "Numéro ou mot de passe invalide."
                };
            }

            // ✅ Génération du token JWT
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, student.Id.ToString()),
                    new Claim(ClaimTypes.Name, student.Nom)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenString = tokenHandler.WriteToken(token);

            return new AuthResponseDto
            {
                Success = true,
                Message = "Connexion réussie.",
                Token = tokenString
            };
        }
    }
}
