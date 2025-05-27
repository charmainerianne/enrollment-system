using System.Linq;
using System.Web.Mvc;
using EnrollmentSystem.Data;
using EnrollmentSystem.Models;

namespace EnrollmentSystem.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly EnrollmentContext _context;

        // Constructor with dependency injection
        public ScheduleController(EnrollmentContext context)
        {
            _context = context;
        }

        // GET: Schedule
        public ActionResult Index()
        {
            var schedules = _context.Schedules.ToList();
            return View(schedules);
        }

        // GET: Schedule/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var schedule = _context.Schedules.FirstOrDefault(s => s.ScheduleId == id);
            if (schedule == null)
            {
                return HttpNotFound();
            }

            return View(schedule);
        }

        // GET: Schedule/Create
        public ActionResult Create()
        {
            ViewBag.Courses = _context.Courses.ToList();
            ViewBag.Rooms = _context.Rooms.ToList();
            ViewBag.Instructors = _context.Instructors.ToList();
            ViewBag.SemesterYears = _context.SemesterYears.ToList();
            return View("Create_New");
        }

        // POST: Schedule/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Schedules.Add(schedule);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Courses = _context.Courses.ToList();
            ViewBag.Rooms = _context.Rooms.ToList();
            ViewBag.Instructors = _context.Instructors.ToList();
            ViewBag.SemesterYears = _context.SemesterYears.ToList();
            return View("Create_New", schedule);
        }

        // GET: Schedule/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var schedule = _context.Schedules.FirstOrDefault(s => s.ScheduleId == id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: Schedule/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Schedule schedule)
        {
            if (id != schedule.ScheduleId)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                var existingSchedule = _context.Schedules.FirstOrDefault(s => s.ScheduleId == id);
                if (existingSchedule == null)
                {
                    return HttpNotFound();
                }

                existingSchedule.CourseId = schedule.CourseId;
                existingSchedule.RoomId = schedule.RoomId;
                existingSchedule.InstructorId = schedule.InstructorId;
                existingSchedule.SemesterYearId = schedule.SemesterYearId;
                existingSchedule.Day = schedule.Day;
                existingSchedule.Time = schedule.Time;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        // GET: Schedule/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var schedule = _context.Schedules.FirstOrDefault(s => s.ScheduleId == id);
            if (schedule == null)
            {
                return HttpNotFound();
            }

            return View(schedule);
        }

        // POST: Schedule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var schedule = _context.Schedules.FirstOrDefault(s => s.ScheduleId == id);
            if (schedule != null)
            {
                _context.Schedules.Remove(schedule);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
