namespace MedikoWeb.Models
{
    public class UserDetailViewModel
    {
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;
       
        public List<RoleSelection> RoleSelections { get; set; } = new List<RoleSelection>();
    }
}
