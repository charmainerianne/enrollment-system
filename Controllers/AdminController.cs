using System.Linq;
using System.Web.Mvc;
using EnrollmentSystem.Data;
using EnrollmentSystem.Models;

namespace EnrollmentSystem.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly EnrollmentContext _context;

        public AdminController(EnrollmentContext context)
        {
            _context = context;
        }

        // GET: Admin/Statistics
        public ActionResult Statistics(int? year)
        {
            if (year == null)
            {
                year = System.DateTime.Now.Year;
            }

            var appliedCount = _context.Students.Count(s => s.EnrollmentStatus == "Applied" && s.YearLevel == year);
            var verifiedCount = _context.Students.Count(s => s.EnrollmentStatus == "Verified" && s.YearLevel == year);
            var deniedCount = _context.Students.Count(s => s.EnrollmentStatus == "Denied" && s.YearLevel == year);

            ViewBag.Year = year;
            ViewBag.AppliedCount = appliedCount;
            ViewBag.VerifiedCount = verifiedCount;
            ViewBag.DeniedCount = deniedCount;

            return View();
        }

        // GET: Admin/Applicants
        public ActionResult Applicants(string status)
        {
            var applicants = _context.Students.AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                applicants = applicants.Where(s => s.EnrollmentStatus == status);
            }

            return View(applicants.ToList());
        }

        // GET: Admin/UpdateProfile/5
        public ActionResult UpdateProfile(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var admin = _context.Admins.FirstOrDefault(a => a.AdminId == id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            return View(admin);
        }

        // POST: Admin/UpdateProfile/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfile(string id, Admin admin)
        {
            if (id != admin.AdminId)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                var existingAdmin = _context.Admins.FirstOrDefault(a => a.AdminId == id);
                if (existingAdmin == null)
                {
                    return HttpNotFound();
                }

                // Update admin properties here if any (e.g., password, name if added)

                _context.SaveChanges();
                return RedirectToAction("Applicants");
            }
            return View(admin);
        }

        // GET: Admin/ChangePassword/5
        public ActionResult ChangePassword(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var admin = _context.Admins.FirstOrDefault(a => a.AdminId == id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            return View(admin);
        }

        // POST: Admin/ChangePassword/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(string id, string newPassword)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.AdminId == id);
            if (admin == null)
            {
                return HttpNotFound();
            }

            // Implement password change logic here (hashing, validation, etc.)
            // For now, just a placeholder
            // admin.PasswordHash = HashPassword(newPassword);

            _context.SaveChanges();
            return RedirectToAction("Applicants");
        }
    }
}
