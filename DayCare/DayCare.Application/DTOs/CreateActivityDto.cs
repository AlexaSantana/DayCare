using System.ComponentModel.DataAnnotations;

namespace DayCare.Application.DTOs
{
    public class CreateActivityDto
    {
        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(50)]
        public string RecommendedGroup { get; set; } = string.Empty;
    }
}
