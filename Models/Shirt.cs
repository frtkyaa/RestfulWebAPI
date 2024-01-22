using System.ComponentModel.DataAnnotations;
using CatalogWebapp.Models.Validations;

namespace CatalogWebapp.Models
{
    public class Shirt
    {
        // Creating Properties ...

        [Required]
        public int ShirtId { get; set; }

        public string? Brand { get; set; } // ? allows the Brand Name to be null 


        [Required]
        public string? Color { get; set; }

    
        [Shirt_EnsureCorrectSizing]
        public int? Size { get; set; }


        [Required]
        public string? Gender { get; set; }

        public double? Price { get; set; }
    }
}






