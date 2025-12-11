using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DayCare.Domain.Entities
{
    public class Tutor
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Relationship { get; set; } = string.Empty; 

        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(120)]
        public string Email { get; set; } = string.Empty;

        public ICollection<Child> Children { get; set; }
    }
}
