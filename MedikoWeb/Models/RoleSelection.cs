namespace MedikoWeb.Models
{
    public class RoleSelection
    {
        public string RoleName { get; set; } = null!;
        public bool IsSelected { get; set; }

        public RoleSelection(string rolename, bool isSelected)
        {
            RoleName = rolename;
            IsSelected = isSelected;
        }
        public RoleSelection()
        {

        }
    }
}
