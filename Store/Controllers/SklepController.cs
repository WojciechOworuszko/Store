using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Repositories;
using Store.Extensions;
using Microsoft.EntityFrameworkCore;
using Store.Data;

namespace Store.Controllers
{
    public class SklepController : Controller
    {
        private readonly SklepManager _manager;
        private readonly SklepContext _context;

        public SklepController(SklepManager manager, SklepContext context)
        {
            _manager = manager;
            _context = context;
        }

        public IActionResult Index()
        {
            var produkty = _manager.GetSklepy();
            return View(produkty);
        }

        public IActionResult Koszyk()
        {
            var koszyk = GetKoszyk();
            return View(koszyk);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var produkt = _manager.GetSklep(id);
            if (produkt == null)
            {
                return NotFound();
            }

            return View(produkt);
        }

        [HttpPost]
        public IActionResult Add(Produkt produkt)
        {
            _manager.DodajProdukt(produkt);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var ProduktToDelete = _manager.GetSklep(id);
            return View(ProduktToDelete);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _manager.UsunProdukt(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ProduktToEdit = _manager.GetSklep(id);
            return View(ProduktToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Produkt produkt)
        {
            _manager.ZaktualizujProdukt(produkt);
            return RedirectToAction("Index");
        }

        public IActionResult DodajDoKoszyka(int id)
        {
            var produkt = _manager.GetSklep(id);
            if (produkt == null)
            {
                return NotFound();
            }

            var koszyk = GetKoszyk();

            var istniejącyElement = koszyk.FirstOrDefault(x => x.ProduktID == produkt.ID);
            if (istniejącyElement != null)
            {
                istniejącyElement.Ilosc++;
            }
            else
            {
                koszyk.Add(new ElementKoszyka
                {
                    ProduktID = produkt.ID,
                    Nazwa = produkt.Nazwa,
                    Cena = produkt.Cena,
                    Ilosc = 1
                });
            }

            ZapiszKoszyk(koszyk);
            return RedirectToAction("Koszyk");
        }

        public IActionResult UsunZKoszyka(int id)
        {
            var koszyk = GetKoszyk();
            var element = koszyk.FirstOrDefault(x => x.ProduktID == id);
            if (element != null)
            {
                koszyk.Remove(element);
                ZapiszKoszyk(koszyk);
            }
            return RedirectToAction("Koszyk");
        }

        [HttpGet]
        public IActionResult Finalizacja()
        {
            return View(new DaneZamawiajacego());
        }

        [HttpPost]
        public IActionResult Finalizacja(DaneZamawiajacego dane)
        {
            var koszyk = GetKoszyk();
            if (koszyk.Count == 0)
            {
                TempData["Error"] = "Koszyk jest pusty.";
                return RedirectToAction("Koszyk");
            }

            var zamowienie = new Zamowienie
            {
                DataZlozenia = DateTime.Now,
                Pozycje = new List<PozycjaZamowienia>()
            };

            var uzytkownikId = HttpContext.Session.GetInt32("UzytkownikId");

            if (uzytkownikId != null)
            {
                var uzytkownik = _manager.GetUzytkownik((int)uzytkownikId);
                if (uzytkownik != null)
                {
                    zamowienie.UzytkownikId = uzytkownik.ID;
                    zamowienie.Imie = uzytkownik.Imie;
                    zamowienie.Nazwisko = uzytkownik.Nazwisko;
                    zamowienie.Email = uzytkownik.email;
                }
            }
            else
            {
                zamowienie.Imie = dane.Imie;
                zamowienie.Nazwisko = dane.Nazwisko;
                zamowienie.Email = dane.Email;
            }

            foreach (var pozycja in koszyk)
            {
                var produkt = _manager.GetSklep(pozycja.ProduktID);

                if (produkt == null || produkt.ilosc < pozycja.Ilosc)
                {
                    TempData["Error"] = $"Brak produktu: {pozycja.Nazwa}";
                    return RedirectToAction("Koszyk");
                }

                produkt.ilosc -= pozycja.Ilosc;
                _manager.ZaktualizujProdukt(produkt);

                zamowienie.Pozycje.Add(new PozycjaZamowienia
                {
                    ProduktID = produkt.ID,
                    Ilosc = pozycja.Ilosc,
                    Cena = produkt.Cena
                });
            }

            _context.Zamowienia.Add(zamowienie);
            _context.SaveChanges();

            HttpContext.Session.Remove("Koszyk");
            TempData["Message"] = "Zamówienie zostało złożone.";
            return RedirectToAction("Index");
        }

        private List<ElementKoszyka> GetKoszyk()
        {
            var koszyk = HttpContext.Session.GetObjectFromJson<List<ElementKoszyka>>("Koszyk");
            if (koszyk == null)
            {
                koszyk = new List<ElementKoszyka>();
                HttpContext.Session.SetObjectAsJson("Koszyk", koszyk);
            }
            return koszyk;
        }

        private void ZapiszKoszyk(List<ElementKoszyka> koszyk)
        {
            HttpContext.Session.SetObjectAsJson("Koszyk", koszyk);
        }

        public IActionResult Informacje()
        {
            return View();
        }


    }
}
