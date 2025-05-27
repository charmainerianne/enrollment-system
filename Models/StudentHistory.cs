using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentSystem.Models
{
    public class StudentHistory
    {
        [Key, Column(Order = 0)]
        public int Stud_ID { get; set; }

        [Key, Column(Order = 1)]
        public string StudHist_Entry { get; set; }

        [ForeignKey("Stud_ID")]
        public virtual Student Student { get; set; }
    }
}
