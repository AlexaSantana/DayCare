using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DayCare.Domain.Entities
{
    public class Child
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(50)]
        public string GroupName { get; set; } = string.Empty; 

        [Required]
        public int TutorId { get; set; }
        public Tutor Tutor { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
