namespace MedikoWeb.Models
{
    public class UserOptionsViewModel
    {
        public string UserId { get; set; } = null!;
        public string UserName { get; set; } = null!;

        public List<LogbookSelection> LogbookSelections { get; set; } = new List<LogbookSelection>();
    }
}
