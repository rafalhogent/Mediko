namespace MedikoWeb.Models
{
    public class LogBookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Field1 { get; set; }
        public string? Unit1 { get; set; }
        public string? Field2 { get; set; }
        public string? Unit2 { get; set; }
        public string? Field3 { get; set; }
        public string? Unit3 { get; set; }
        public int Precision { get; set; } = 0;
        public string? IconUrl { get; set; } = null;
    }
}
