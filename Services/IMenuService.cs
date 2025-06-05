using System.Collections.Generic;
using System.Threading.Tasks;
using cantine_univ.DTOs;

namespace cantine_univ.Services
{
    public interface IMenuService
    {
        Task<List<MenuDto>> GetMenusAsync();
        Task<MenuDto> GetMenuByIdAsync(int id);
        Task<MenuDto> CreateMenuAsync(MenuDto dto);
        Task<bool> DeleteMenuAsync(int id);
    }
}
