using System;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }

        [Required]
        public string CourseId { get; set; }

        public string Room { get; set; }

        public string Instructor { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}
