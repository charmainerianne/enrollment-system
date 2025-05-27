using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Models
{
    public class Instructor
    {
        [Key]
        public int Instr_ID { get; set; }
        public string Instr_Name { get; set; }
    }
}
