namespace Store.Models
{
    public class ElementKoszyka
    {
        public int ProduktID { get; set; } 
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }

        public decimal Wartosc => Cena * Ilosc; 
    }
}
