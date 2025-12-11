using System.ComponentModel.DataAnnotations;

namespace DayCare.Application.DTOs
{
    public class CreateAttendanceDto
    {
        [Required]
        public int ChildId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public string Status { get; set; } = "Presente";

        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
    }
}
