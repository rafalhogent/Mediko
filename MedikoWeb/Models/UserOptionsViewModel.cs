namespace MedikoWeb.Models
{
    public class UserOptionsViewModel
    {
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;

        public List<LogbookSelection> LogbookSelections { get; set; } = new List<LogbookSelection>();

        public string? Message { get; set; }

        public bool PasswordEditingAllowed { get; set; } = true;
    }

    public class LogbookSelection
    {
        public string LogbookName { get; set; } = null!;
        public int LogbookId { get; set; }

        public bool IsSelected { get; set; } = true;

        public bool Editable { get; set; }

        public LogbookSelection(string name, bool isSelected)
        {
            LogbookName = name;
            IsSelected = isSelected;
        }
        public LogbookSelection()
        {

        }
    }
}
