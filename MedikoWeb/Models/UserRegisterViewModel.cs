using System.ComponentModel.DataAnnotations;

namespace MedikoWeb.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Gebruikersnaam is verplicht")]
        [MinLength(3, ErrorMessage = "Gebruikersnaam - minstens 3 tekens")]
        [MaxLength(50, ErrorMessage = "Gebruikersnaam -  max 50 tekens")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [MinLength(6, ErrorMessage = "Wachtwoord - minstens 6 tekens")]
        public string Password { get; set; } = null!;
    }
}
