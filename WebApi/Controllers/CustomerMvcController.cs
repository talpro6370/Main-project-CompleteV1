using MainProject.Pocos;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApiPart.Controllers
{
    public class CustomerMvcController : Controller
    {

        public static async Task Execute(CustomerRegistraionInfo customerInfo)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("talpro6370@gmail.com");
            var subject = "Confirmation Email";
            var to = new EmailAddress(customerInfo.Email);
            var plainTextContent = "and easy to do anywhere, even with C#";
            myGuid = Guid.NewGuid().ToString();
            var htmlContent = "Click here to verify your account:<br>http://localhost:58981/CustomerMvc/ConfirmEmail?guid=" + myGuid;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
        public static string myGuid = null;
        AnonymousFacadeController ano = new AnonymousFacadeController();
        // GET: CustomerMvc
        public ActionResult Email(CustomerRegistraionInfo customerInfo)
        {

            Execute(customerInfo).Wait(3000);

            return Content("Email sent");
        }
        public ActionResult ConfirmEmail()
        {
            var req = Request.QueryString;
            var guid = req.Get("guid");

            if (guid == myGuid)
                return new FilePathResult("~/Views/CustomerRegistration/LoginPageCustomer.html", "text/html");
            return Content("Email has not confirmed!");
        }
    }
}