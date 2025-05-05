using Microsoft.EntityFrameworkCore;
using Store.Models;
namespace Store.Data
{
    public class SklepContext: DbContext
    {
        public SklepContext(DbContextOptions<SklepContext>options) 
        :base(options) 
        { 
        }

        public DbSet<Produkt> Produkty { get; set; }

        public DbSet<Uzytkownicy> Uzytkownicy { get; set; }


        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<PozycjaZamowienia> PozycjeZamowien { get; set; }

    }
}
