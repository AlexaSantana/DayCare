using System.ComponentModel.DataAnnotations;

namespace DayCare.Domain.Entities
{
    public class Activity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = string.Empty; 

        [MaxLength(300)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(50)]
        public string RecommendedGroup { get; set; } = string.Empty; 
    }
}
