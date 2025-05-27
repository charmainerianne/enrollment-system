using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Models
{
    public class Course
    {
        [Key]
        public string CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
