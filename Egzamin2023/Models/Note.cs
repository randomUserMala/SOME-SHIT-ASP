// ZADANIE 1. MODEL NOTE, KLASA, WIDOK, CONTROLLER

using System.ComponentModel.DataAnnotations; // dodajemy DataAnnotations aby móc używać [display], [key] itp.
namespace Egzamin2023.Models
{
	public class Note
	{
		[Key] // "identyfikator" 
		[MinLength(3)] // minimalna długość znaków
		[MaxLength(20)] // maksymalna długość znaków
        [Display(Name = "Tytuł")] // wyświetlana nazwa
        public string Title { get; set; }


        [MinLength(10)] // minimalna długość znaków
        [MaxLength(2000)] // maksymalna długość znaków
        [Display(Name = "Treść")] // wyświetlana nazwa
        public string Content { get; set; }


        [Display(Name = "Data ważności")] // wyświetlana nazwa
        public DateTime Deadline { get; set; }
	}
}

