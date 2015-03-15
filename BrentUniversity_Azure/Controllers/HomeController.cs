using System.Web.Mvc;
using BrentUniversity_Azure.Helper;

namespace BrentUniversity_Azure.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult MyProfile()
        {
            return View();
        }

        public FileResult DownloadPdf()
        {
            var filePath = Server.MapPath("~/Content/resume/BrentonBates_WebDev_Resume.pdf");
            var pdfFileBytes = FileHelper.GetBytesFromFile(filePath);
            return File(pdfFileBytes, "application/pdf", "Brenton Bates Business Application Developer.pdf");
        }

    }
}