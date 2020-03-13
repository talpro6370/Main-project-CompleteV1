using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApiPart.Controllers
{
    public class CustomerRegistrationController : Controller
    {
        public ActionResult RegisterPageCustomer()
        {
            return new FilePathResult("~/Views/CustomerRegistration/RegisterPageCustomer.html", "text/html");
        }
        public ActionResult LoginPageCustomer()
        {
            return new FilePathResult("~/Views/CustomerRegistration/LoginPageCustomer.html", "text/html");
        }
        public ActionResult ConfirmationPage()
        {
            return new FilePathResult("~/Views/CustomerRegistration/ConfirmationPage.html", "text/html");
        }
    }
}