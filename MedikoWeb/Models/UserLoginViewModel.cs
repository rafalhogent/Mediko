using System.ComponentModel.DataAnnotations;

namespace MedikoWeb.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Naam is verplicht")]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        public string Password { get; set; } = null!;
    }
}
