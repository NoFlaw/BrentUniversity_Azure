using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrentUniversity_Azure.Data;
using BrentUniversity_Azure.Service;

namespace BrentUniversity_Azure.Controllers
{
    public class CoolController : Controller
    {
        private readonly StudentService _studentService;

        public CoolController(StudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Cool
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllStudents()
        {
            //var students = _studentService.GetAll().ToList();
                //_studentService.GetAllStudents().Select(n => new { id = n.Id, n.FirstName, n.LastName, n.EnrollmentDate });
            return Json(_studentService.GetAll(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<Student> students)
        {
            // Can process the data any way we want here,
            // e.g., further server-side validation, save to database, etc
            return View("Saved", students);
        }
    }
}