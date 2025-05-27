using System;
using System.Linq;
using System.Web.Mvc;
using EnrollmentSystem.Data;
using EnrollmentSystem.Models;

namespace EnrollmentSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly EnrollmentContextLegacy _context;

        public AccountController()
        {
            _context = new EnrollmentContextLegacy();
        }

        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(string userId, string password, string userType)
        {
            if (string.IsNullOrEmpty(userId) && userType == "Admin")
            {
                ModelState.AddModelError("UserId", "User ID is required.");
            }
            if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("Password", "Password is required.");
            }
            if (string.IsNullOrEmpty(userType))
            {
                ModelState.AddModelError("UserType", "User type is required.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (userType == "Admin")
            {
                var admin = _context.Admins.FirstOrDefault(a => a.AdminId == userId && a.Password == password);
                if (admin == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Admin ID or Password.");
                    return View();
                }
                Session["AdminId"] = admin.AdminId;
                return RedirectToAction("Dashboard", "Admin");
            }
            else if (userType == "Student")
            {
                DateTime birthday;
                if (!DateTime.TryParse(userId, out birthday))
                {
                    ModelState.AddModelError(string.Empty, "Invalid birthday format.");
                    return View();
                }
                var student = _context.Students.FirstOrDefault(s => s.Birthday == birthday && s.Password == password);
                if (student == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid Birthday or Password.");
                    return View();
                }
                Session["StudentId"] = student.StudentId;
                return RedirectToAction("Dashboard", "Student");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid user type.");
                return View();
            }
        }

        // GET: /Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register_New");
        }

        // POST: /Account/Register
        [HttpPost]
        public ActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = _context.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
                if (existingStudent != null)
                {
                    ModelState.AddModelError("StudentId", "Student ID already exists.");
                    return View("Register_New", student);
                }

                _context.Students.Add(student);
                _context.SaveChanges();

                Session["StudentId"] = student.StudentId;

                return RedirectToAction("Dashboard", "Student");
            }
            return View("Register_New", student);
        }

        // GET: /Account/Logout
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
