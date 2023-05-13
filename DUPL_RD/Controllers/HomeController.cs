using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DUPL_RD.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DUPL_RD.Controllers
{
    public class HomeController : Controller
    {
        BookDbContext db = new BookDbContext();

        public ActionResult BookList()
        {
            return View(db.Books.ToList());
        }
        //public ActionResult exportReport( DateTime fromDate, DateTime toDate)
        //{
        //    ReportDocument reportDocument = new ReportDocument();
        //    reportDocument.Load(Path.Combine(Server.MapPath("~/Report"), "BooksCrystalReport.rpt"));

        //    reportDocument.SetParameterValue("FromDate", fromDate);
        //    reportDocument.SetParameterValue("ToDate", toDate);

        //    reportDocument.SetDataSource(db.Books.ToList());
        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();
        //    try
        //    {
        //        Stream stream = reportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //        return File(stream, "application/pdf");
        //    }
        //    catch
        //    {

        //        throw;
        //    }
        //}

        public ActionResult exportReport(DateTime fromDate, DateTime toDate)
        {
            // Set up the Crystal Report parameters
            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("~/Report/BooksCrystalReport.rpt"));
            report.SetParameterValue("fromDate", fromDate);
            report.SetParameterValue("toDate", toDate);

            // Export the report to PDF
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            //report.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, "BookReport.pdf");
            Stream stream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");

            //return new EmptyResult();
        }
        //


        private List<Book> books = new List<Book>
        {
            // Populate your events data here
        };

        public ActionResult Index()
        {
            return View(books);
        }

        [HttpPost]
        public ActionResult Search(DateTime startDate, DateTime endDate)
        {
            var results = books.Where(e => e.Date >= startDate && e.Date <= endDate).ToList();
            return PartialView("_BookList", results);
        }
        

        //
        //public IEnumerable<Book> results { get; set; }
        //public void OnGet()
        //{
        //    results=db.Books.ToList();
        //}
        //public void OnPost(DateTime startdate, DateTime enddate)
        //{
        //    results=(from x in db.Books where(x.Date<= startdate)&&(x.Date>=enddate)select x).ToList();
        //}


        //public ActionResult Index()
        //{
        //    return View();
        //}

        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}