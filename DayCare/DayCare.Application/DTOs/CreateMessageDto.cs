using System.ComponentModel.DataAnnotations;

namespace DayCare.Application.DTOs
{
    public class CreateMessageDto
    {
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; } = string.Empty;

        [MaxLength(30)]
        public string MessageType { get; set; } = "Individual";

        public int? ChildId { get; set; }
    }
}
