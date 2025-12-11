namespace DayCare.Application.DTOs
{
    public class AttendanceDto
    {
        public int AttendanceId { get; set; }
        public int ChildId { get; set; }
        public string ChildName { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }

        // Para el input HTML
        public string? CheckInTimeString { get; set; }
        public string? CheckOutTimeString { get; set; }

        public void ParseTimes()
        {
            if (TimeSpan.TryParse(CheckInTimeString, out var cin))
                CheckInTime = cin;

            if (TimeSpan.TryParse(CheckOutTimeString, out var cout))
                CheckOutTime = cout;
        }
    }

}
