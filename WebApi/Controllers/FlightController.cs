using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiPart.Controllers
{
    public class FlightController : Controller
    {
        public ActionResult GetFlights()
        {
            return new FilePathResult("~/Views/Flight/getFlights.html","text/html");
        }
        public ActionResult getArrivals()
        {
            return new FilePathResult("~/Views/Flight/getArrivals.html", "text/html");
        }
        public ActionResult homepage1()
        {
            return new FilePathResult("~/Views/Flight/homepage1.html", "text/html");
        }
        public ActionResult SearchPage()
        {
            return new FilePathResult("~/Views/Flight/SearchPage.html", "text/html");
        }
        
    }
}