using System;
using System.ComponentModel.DataAnnotations;

namespace DayCare.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public DateTime SentDate { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty; 

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; } = string.Empty;

        [MaxLength(30)]
        public string MessageType { get; set; } = "Individual";
        public int? ChildId { get; set; }
        public Child Child { get; set; }
    }
}
