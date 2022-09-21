using MedikoData.Entities;
using System.ComponentModel.DataAnnotations;

namespace MedikoWeb.Models
{
    public class DiaryViewModel
    {
        public LogBook Logbook { get; set; } = null!;
        public List<Log> UserLogs { get; set; } = new List<Log>();

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime Czas { get; set; } = DateTime.Now;

        public LogViewModel NewLog { get; set; } = null!;

        public string? Message { get; set; }


    }
}
