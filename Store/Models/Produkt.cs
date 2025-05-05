using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Produkt
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Nazwa { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}", ApplyFormatInEditMode = true)]
        public decimal Cena { get; set; }

        public int ilosc { get; set; }

        public string? Opis { get; set; }
        public string? ZdjecieUrl { get; set; }
    }
}

