using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Models
{
    public class Program
    {
        [Key]
        public int Prog_ID { get; set; }
        public string Prog_Name { get; set; }
        public int Prog_Year { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<SemesterYear> SemesterYears { get; set; }
    }
}
