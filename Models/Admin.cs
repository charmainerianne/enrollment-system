using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Models
{
    public class Admin
    {
        [Key]
        public string AdminId { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
