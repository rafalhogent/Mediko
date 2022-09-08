using System.ComponentModel.DataAnnotations;

namespace MedikoData.Entities
{
    public class LogBook
    {
        [Key]
        public int LogBookId { get; set; }
        [Required]
        public string Name { get; set; } = null!;


        public string? Field1 { get; set; }
        public string? Unit1 { get; set; }
        public string? Field2 { get; set; }
        public string? Unit2 { get; set; }
        public string? Field3 { get; set; }
        public string? Unit3 { get; set; }
        public int Precision { get; set; } = 0;
        public string? IconUrl { get; set; } = null;

        public AppUser? Creator { get; set; }

        
        public ICollection<Log> Logs { get; set; } = null!;
    }
}