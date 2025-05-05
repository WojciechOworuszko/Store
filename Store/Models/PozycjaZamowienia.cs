namespace Store.Models
{
    public class PozycjaZamowienia
    {
        public int ID { get; set; }

        public int ZamowienieID { get; set; }
        public Zamowienie Zamowienie { get; set; }

        public int ProduktID { get; set; }
        public Produkt Produkt { get; set; }

        public int Ilosc { get; set; }
        public decimal Cena { get; set; } 
    }
}

