namespace DayCare.Application.DTOs
{
    public class UpdateAttendanceDto
    {
        public string Status { get; set; } = "Presente";
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
    }
}
