using System.Linq;
using System.Web.Mvc;
using EnrollmentSystem.Data;
using EnrollmentSystem.Models;

namespace EnrollmentSystem.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly EnrollmentContext _context;

        // Constructor with dependency injection
        public EnrollmentController(EnrollmentContext context)
        {
            _context = context;
        }

        // GET: Enrollment
        public ActionResult Index()
        {
            var enrollments = _context.Enrollments.ToList();
            return View(enrollments);
        }

        // GET: Enrollment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enrollment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                _context.Enrollments.Add(enrollment);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enrollment);
        }

        // GET: Enrollment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var enrollment = _context.Enrollments.FirstOrDefault(e => e.EnrollmentId == id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentId)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                var existingEnrollment = _context.Enrollments.FirstOrDefault(e => e.EnrollmentId == id);
                if (existingEnrollment == null)
                {
                    return HttpNotFound();
                }

                existingEnrollment.StudentId = enrollment.StudentId;
                existingEnrollment.CourseId = enrollment.CourseId;
                existingEnrollment.SemesterYearId = enrollment.SemesterYearId;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var enrollment = _context.Enrollments.FirstOrDefault(e => e.EnrollmentId == id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var enrollment = _context.Enrollments.FirstOrDefault(e => e.EnrollmentId == id);
            if (enrollment != null)
            {
                _context.Enrollments.Remove(enrollment);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
