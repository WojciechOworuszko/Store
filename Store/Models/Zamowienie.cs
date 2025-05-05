using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Zamowienie
    {
        public int ID { get; set; }

        public DateTime DataZlozenia { get; set; } = DateTime.Now;

        public int? UzytkownikId { get; set; }
        public Uzytkownicy? Uzytkownik { get; set; }

        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Email { get; set; }

        public List<PozycjaZamowienia> Pozycje { get; set; } = new();
    }
}
