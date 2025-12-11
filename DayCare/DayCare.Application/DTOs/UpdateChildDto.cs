using System;
using System.ComponentModel.DataAnnotations;

namespace DayCare.Application.DTOs
{
    public class UpdateChildDto
    {
        [Required]
        [MaxLength(120)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(50)]
        public string GroupName { get; set; } = string.Empty;

        [Required]
        public int TutorId { get; set; }
    }
}
