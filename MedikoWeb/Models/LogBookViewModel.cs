using System.ComponentModel.DataAnnotations;

namespace MedikoWeb.Models
{
    public class LogBookViewModel
    {
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "Geef minstens 2 tekens!")]
        [MaxLength(40, ErrorMessage = "Geef max 40 tekens!")]
        [Required(ErrorMessage = "{0} is verplicht")]
        [Display(Name = "Naam")]
        public string Name { get; set; } = null!;
        public string? Field1 { get; set; }
        public string? Unit1 { get; set; }
        public string? Field2 { get; set; }
        public string? Unit2 { get; set; }
        public string? Field3 { get; set; }
        public string? Unit3 { get; set; }

        [Required(ErrorMessage = "Precision is verplicht")]
        [Range(0,4, ErrorMessage = "Minimum 0, maximum 4")]
        public int Precision { get; set; } = 0;
        public string? IconUrl { get; set; } = null;
    }
}
