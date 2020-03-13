using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MainProject;
using MainProject.Business_Logic;
using WebApiPart.Controllers.BasicAuthAtt;

namespace WebApiPart.Controllers
{
    [BasicCustomerAuthenticationAttribute]
    public class CustomerFacadeController : ApiController
    {
        LoginToken<Customer> customerLoginToken;
        LoggedInCustomerFacade customerFacade = new LoggedInCustomerFacade();
        Models.LoginHelpClass customerLoginHelp = new Models.LoginHelpClass();

        public LoggedInCustomerFacade getCustomerFacade()
        {
            Request.Properties.TryGetValue("login-customer", out object loginUser);
            customerLoginToken = (LoginToken<Customer>)loginUser;
            FacadeBase LoginIFacade = FlyingCenterSystem.GetInstance().GetFacade(customerLoginToken);
            return (LoggedInCustomerFacade)LoginIFacade;
        }

        [Route("api/customer/ShowAllMyFlights")]
        [HttpGet]
        public IHttpActionResult GetAllMyFlights()
        {
            LoginToken<Customer> customerToken = customerLoginHelp.GetCustomerToken();
            try
            {
                return Ok(getCustomerFacade().GetAllMyFlights(customerLoginToken));
                //return Ok(customerFacade.GetAllMyFlights(customerLoginToken));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [ResponseType(typeof(Tickets))]
        [Route("api/customer/PurchaseTicket")]
        [HttpPut]
        public IHttpActionResult PurchaseTicket(Flight flight)
        {
            LoginToken<Customer> customerToken = customerLoginHelp.GetCustomerToken();
            try
            {
                return Ok(customerFacade.PurchaseTicket(customerToken, flight));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult CancelTicket(Tickets ticket)
        {
            LoginToken<Customer> customerToken = customerLoginHelp.GetCustomerToken();
            try
            {
                customerFacade.CancelTicket(customerToken, ticket);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

    }
}
