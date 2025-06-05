using cantine_univ.Models;
using Microsoft.EntityFrameworkCore;

namespace cantine_univ.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Menus.Any())
            {
                context.Menus.AddRange(
                    new Menu { Plat = "Riz au poulet", Description = "Servi avec sauce tomate", Jour = DateTime.Today },
                    new Menu { Plat = "Spaghetti bolognaise", Description = "Avec viande hachée", Jour = DateTime.Today.AddDays(1) }
                );

                context.SaveChanges();
            }
        }
    }
}
