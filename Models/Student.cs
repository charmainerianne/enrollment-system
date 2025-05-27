using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Models
{
    public enum StudentType
    {
        Regular,
        Irregular,
        Shifted
    }

    public class Student
    {
        [Key]
        public string StudentId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string MiddleInitial { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public int YearLevel { get; set; }

        [Required]
        public string Program { get; set; }

        [Required]
        public StudentType StudentType { get; set; }

        [Required]
        public string Password { get; set; }

        public string EnrollmentStatus { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
