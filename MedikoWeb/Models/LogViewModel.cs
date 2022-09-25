using System.ComponentModel.DataAnnotations;

namespace MedikoWeb.Models
{
    public class LogViewModel
    {
        public int LogbookId { get; set; }
        public int? logId { get; set; }

        //public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        //public TimeOnly Time { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        //[DisplayFormat(DataFormatString = "{0:d/M/yyyy HH:mm}")]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.DateTime), Required]
        //[DisplayFormat(DataFormatString = "{0:r}", ApplyFormatInEditMode = true)]

        //[DataType(DataType.DateTime)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime DateAndTime { get; set; }
        public float? Value1 { get; set; }
        public float? Value2 { get; set; }
        public float? Value3 { get; set; }
        public string? Comment { get; set; }
    }
}
