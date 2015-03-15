using System.IO;
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

        public FileResult ViewPdf()
        {
            var filePath = Server.MapPath("~/Content/resume/BrentonBates_WebDev_Resume.pdf");
            var pdfFileBytes = FileHelper.GetBytesFromFile(filePath);
            //Forcing into MemoryStream in order to clear response and add inline header for viewing in new tab
            var stream = new MemoryStream();
            stream.Write(pdfFileBytes, 0, pdfFileBytes.Length);
            stream.Position = 0;
            HttpContext.Response.Clear();
            HttpContext.Response.AddHeader("content-disposition", "inline; filename=Brenton Bates Business Application Developer.pdf");
            return File(stream, "application/pdf");
        }

        public FileResult DownloadPdf()
        {
            var filePath = Server.MapPath("~/Content/resume/BrentonBates_WebDev_Resume.pdf");
            var pdfFileBytes = FileHelper.GetBytesFromFile(filePath);
            return File(pdfFileBytes, "application/pdf", "Brenton Bates Business Application Developer.pdf");
        }

    }
}