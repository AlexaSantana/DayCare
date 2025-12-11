using System.ComponentModel.DataAnnotations;

namespace DayCare.Application.DTOs
{
    public class CreateTutorDto
    {
        [Required]
        [MaxLength(120)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Relationship { get; set; } = string.Empty;

        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(120)]
        public string Email { get; set; } = string.Empty;
    }
}
