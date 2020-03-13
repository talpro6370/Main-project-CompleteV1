using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiPart.Controllers
{
    public class FutureFlightController : Controller
    {
        // GET: FutureFlight
        public ActionResult FutureFlightPage()
        {
            return new FilePathResult("~/Views/FutureFlight/FutureFlightPage.html", "text/html");
        }
    }
}