using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentSystem.Models
{
    public class TeachAssignment
    {
        [Key]
        public int Mis_Code { get; set; }

        public int Instr_ID { get; set; }
        public int Course_Code { get; set; }
        public int Room_ID { get; set; }
        public string TA_Room_Hours { get; set; }
        public string TA_Room_Day { get; set; }

        [ForeignKey("Instr_ID")]
        public virtual Instructor Instructor { get; set; }

        [ForeignKey("Course_Code")]
        public virtual Course Course { get; set; }

        [ForeignKey("Room_ID")]
        public virtual Room Room { get; set; }
    }
}
