using System;
using System;
using System.ComponentModel.DataAnnotations;

namespace DayCare.Domain.Entities
{
    public class Attendance
    {
        public int Id { get; set; }

        [Required]
        public int ChildId { get; set; }
        public Child Child { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = "Presente"; 

        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
    }
}
