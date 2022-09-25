using System.ComponentModel.DataAnnotations;

namespace MedikoWeb.Models
{
    public class UserEditPasswordViewModel
    {
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "Oude Wachtwoord is verplicht")]
        public string OldPassword { get; set; } = null!;

        [Required(ErrorMessage = "Nieuwe Wachtwoord is verplicht")]
        public string NewPassword { get; set; } = null!;
    }
}
