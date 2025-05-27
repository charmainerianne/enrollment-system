using System.Linq;
using System.Web.Mvc;
using EnrollmentSystem.Data;
using EnrollmentSystem.Models;

namespace EnrollmentSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly EnrollmentContext _context;

        public StudentController(EnrollmentContext context)
        {
            _context = context;
        }

        // GET: Student
        public ActionResult Index()
        {
            var studentId = Session["StudentId"] as string;
            if (string.IsNullOrEmpty(studentId))
            {
                return RedirectToAction("Login", "Account");
            }

            var student = _context.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        // GET: Student/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var student = _context.Students.FirstOrDefault(m => m.StudentId == id);
            if (student == null)
            {
                return HttpNotFound();
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var student = _context.Students.FirstOrDefault(m => m.StudentId == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Student student)
        {
            if (id != student.StudentId)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                var existingStudent = _context.Students.FirstOrDefault(s => s.StudentId == id);
                if (existingStudent == null)
                {
                    return HttpNotFound();
                }

                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.MiddleInitial = student.MiddleInitial;
                existingStudent.Birthday = student.Birthday;
                existingStudent.YearLevel = student.YearLevel;
                existingStudent.Program = student.Program;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
