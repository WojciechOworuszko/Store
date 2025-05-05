using System.ComponentModel.DataAnnotations;
namespace Store.Models
{
    public class Uzytkownicy
    {
        public int ID { get; set; }
        [Required]
        public string Nazwisko { get; set; }

        [Required]
        public string Imie { get; set; }

        public string NumerTelefonu { get; set; }

        [Required]
        public string email { get; set; }
        
        [Required]
        public string login { get; set; }
        
        [Required]
        public string haslo { get; set; }
        
        [Required]
        public string KodPocztowy { get; set; }
        
        [Required]
        public string Miasto { get; set; }
        
        [Required]
        public string UlicaNumerDomuMieszkania { get; set; }


    }
}
