using System.Net;
using System.Web.Mvc;
using BrentUniversity_Azure.Data;
using BrentUniversity_Azure.Service.Base;

namespace BrentUniversity_Azure.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        // Constructor
        public StudentController()
        {
        }

        // Dependency Injected Constructor
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        

        // GET: Student
        public ActionResult Index()
        {
            return View(_studentService.GetAll());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var student = _studentService.GetById((int)id);
            if (student == null) return HttpNotFound();
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (!ModelState.IsValid) return View(student);
            _studentService.Create(student);
            return RedirectToAction("Index");
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var student = _studentService.GetById((int)id);
            if (student == null) return HttpNotFound();
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,EnrollmentDate")] Student student)
        {
            if (!ModelState.IsValid) return View(student);
            _studentService.Update(student);
            return RedirectToAction("Index");
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var student = _studentService.GetById((int)id);
            if (student == null) return HttpNotFound();
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = _studentService.GetById(id);
            _studentService.Delete(student);
            return RedirectToAction("Index");
        }

    }
}
