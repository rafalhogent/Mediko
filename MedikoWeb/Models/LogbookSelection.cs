
namespace MedikoWeb.Models
{
    public class LogbookSelection
    {
        public string LogbookName { get; set; } = null!;
        public int LogbookId { get; set; }
        public bool IsSelected { get; set; }

        public LogbookSelection(string rolename, bool isSelected)
        {
            LogbookName = rolename;
            IsSelected = isSelected;
        }
        public LogbookSelection()
        {

        }
    }
}

