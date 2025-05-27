using System.Data.Entity;
using EnrollmentSystem.Models;

namespace EnrollmentSystem.Data
{
    public class EnrollmentContext : DbContext
    {
        public EnrollmentContext() : base("name=EnrollmentContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<SemesterYear> SemesterYears { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<TeachAssignment> TeachAssignments { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<StudentHistory> StudentHistories { get; set; }
        public DbSet<AdminHistory> AdminHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Fluent API configurations if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
