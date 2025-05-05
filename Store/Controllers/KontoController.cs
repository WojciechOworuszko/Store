using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Data;

namespace Store.Controllers
{
    public class KontoController : Controller
    {
        private readonly SklepContext _context;

        public KontoController(SklepContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Rejestracja()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Rejestracja(Uzytkownicy model)
        {
            if (ModelState.IsValid)
            {

                if (_context.Uzytkownicy.Any(u => u.login == model.login))
                {
                    ModelState.AddModelError("login", "Login jest już zajęty.");
                    return View(model);
                }

                _context.Uzytkownicy.Add(model);
                _context.SaveChanges();
                TempData["Message"] = "Konto zostało utworzone. Zaloguj się.";
                return RedirectToAction("Logowanie");
            }
            return View(model);

        }

        [HttpGet]
        public IActionResult Logowanie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Logowanie(string login, string haslo)
        {
            var uzytkownik = _context.Uzytkownicy
                .FirstOrDefault(u => u.login == login && u.haslo == haslo);

            if (uzytkownik != null)
            {
                HttpContext.Session.SetInt32("UzytkownikId", uzytkownik.ID);
                HttpContext.Session.SetString("UzytkownikImie", uzytkownik.Imie);
                TempData["Message"] = $"Witaj, {uzytkownik.Imie}!";
                return RedirectToAction("Index", "Sklep");
            }

            ViewBag.Błąd = "Nieprawidłowy login lub hasło";
            return View();
        }

        public IActionResult Wyloguj()
        {
            HttpContext.Session.Clear();
            TempData["Message"] = "Zostałeś wylogowany.";
            return RedirectToAction("Index", "Sklep");
        }




    }
}
