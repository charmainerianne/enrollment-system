using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Models
{
    public class SemesterYear
    {
        [Key]
        public int SemesterYearId { get; set; }

        [Required]
        public string Semester { get; set; }

        [Required]
        public int Year { get; set; }
    }
}
