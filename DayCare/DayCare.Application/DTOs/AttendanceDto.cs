namespace DayCare.Application.DTOs
{
    public class AttendanceDto
    {
        public int Id { get; set; }
        public int ChildId { get; set; }
        public string ChildName { get; set; } = string.Empty;

        public DateTime Date { get; set; }
        public string Status { get; set; } = "Presente";
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
    }
}
