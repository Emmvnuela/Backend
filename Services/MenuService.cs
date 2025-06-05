using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cantine_univ.Data;
using cantine_univ.DTOs;
using cantine_univ.Models;
using Microsoft.EntityFrameworkCore;

namespace cantine_univ.Services
{
    public class MenuService : IMenuService
    {
        private readonly ApplicationDbContext _context;

        public MenuService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MenuDto>> GetMenusAsync()
        {
            return await _context.Menus
                .Select(m => new MenuDto
                {
                    Id = m.Id,
                    Plat = m.Plat,
                    Description = m.Description,
                    Jour = m.Jour
                })
                .ToListAsync();
        }

        public async Task<MenuDto> GetMenuByIdAsync(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null) return null;

            return new MenuDto
            {
                Id = menu.Id,
                Plat = menu.Plat,
                Description = menu.Description,
                Jour = menu.Jour
            };
        }

        public async Task<MenuDto> CreateMenuAsync(MenuDto dto)
        {
            var menu = new Menu
            {
                Plat = dto.Plat,
                Description = dto.Description,
                Jour = dto.Jour
            };

            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();

            dto.Id = menu.Id;
            return dto;
        }

        public async Task<bool> DeleteMenuAsync(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null) return false;

            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
