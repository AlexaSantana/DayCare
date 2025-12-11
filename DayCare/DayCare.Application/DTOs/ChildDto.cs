namespace DayCare.Application.DTOs
{
    public class ChildDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string GroupName { get; set; } = string.Empty;

        public int TutorId { get; set; }
        public string TutorName { get; set; } = string.Empty;
    }
}
