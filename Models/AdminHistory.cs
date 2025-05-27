using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentSystem.Models
{
    public class AdminHistory
    {
        [Key, Column(Order = 0)]
        public int Admin_ID { get; set; }

        [Key, Column(Order = 1)]
        public string AdHist_Entry { get; set; }

        [ForeignKey("Admin_ID")]
        public virtual Admin Admin { get; set; }
    }
}
