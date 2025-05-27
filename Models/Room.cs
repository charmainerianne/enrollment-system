using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Models
{
    public class Room
    {
        [Key]
        public int Room_ID { get; set; }
        public string Room_Hours { get; set; }
        public string Room_Days { get; set; }
    }
}
