using Store.Data;
using Store.Models;

namespace Store.Repositories
{
    public class SklepManager
    {

        private SklepContext _context;
        public SklepManager(SklepContext context)
        {
            _context = context;
        }

        public SklepManager DodajProdukt(Produkt Produkt) 
        {
            _context.Produkty.Add(Produkt);
            _context.SaveChanges();
            return this;
        }

        public SklepManager UsunProdukt(int ID)
        {
            var elementToDelete = _context.Produkty.SingleOrDefault(x => x.ID == ID);
            if (elementToDelete != null)
            {
                _context.Produkty.Remove(elementToDelete);
                _context.SaveChanges();
            }
            return this;
        }


        public SklepManager ZaktualizujProdukt(Produkt Produkt)
        {
            _context.Produkty.Update(Produkt);
            _context.SaveChanges();
            return this;
        }

        public SklepManager ZmienNazweProduktu(int ID, string Nazwa)
        {
            return this;
        }

        public Produkt GetSklep(int ID)
        {
            var produkt = _context.Produkty.SingleOrDefault(x => x.ID == ID);
            return produkt;
        }


        public List<Produkt> GetSklepy()
        {
            var produkty = _context.Produkty.ToList();
            return produkty;
        }

        public Uzytkownicy GetUzytkownik(int id)
        {
            var uzytkownik = _context.Uzytkownicy.FirstOrDefault(u => u.ID == id);
            return uzytkownik;
        }




    }
}
