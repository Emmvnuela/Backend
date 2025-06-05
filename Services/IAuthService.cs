using System.Threading.Tasks;
using cantine_univ.DTOs;

namespace cantine_univ.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto> LoginAsync(LoginDto dto);
    }
}
