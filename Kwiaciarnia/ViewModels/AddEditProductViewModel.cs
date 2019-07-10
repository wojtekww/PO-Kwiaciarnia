using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kwiaciarnia.ViewModels
{
    public class AddEditProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Podaj nazwę!")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Kategoria")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Podaj cenę!")]
        [DataType(DataType.Currency, ErrorMessage = "Nieprawidłowy format!")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        [Display(Name = "Url zdjęcia")]
        public string ImageUrl { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }    

    }
}
