namespace DayCare.Application.DTOs
{
    public class MessageDto
    {
        public int Id { get; set; }
        public DateTime SentDate { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string MessageType { get; set; } = string.Empty;

        public int? ChildId { get; set; }
        public string? ChildName { get; set; }
    }
}
