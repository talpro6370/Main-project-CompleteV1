using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MainProject;
using MainProject.Business_Logic;
using MainProject.InterFaces;

namespace WebApiPart.Controllers
{
    [BasicAdminAuthentication]
    public class AdministratorFacadeController : ApiController  
    {
        LoginToken<Administrator> adminLoginToken;
        Models.LoginHelpClass help = new Models.LoginHelpClass();
        LoggedInAdministratorFacade adminFacade = new LoggedInAdministratorFacade();
        LoggedInCustomerFacade customerFacade = new LoggedInCustomerFacade();

        public LoggedInAdministratorFacade getAdminLoginToken()
        {
            Request.Properties.TryGetValue("login-token", out object loginUser);
            adminLoginToken = (LoginToken<Administrator>)loginUser;
            FacadeBase LoginIFacade = FlyingCenterSystem.GetInstance().GetFacade(adminLoginToken);
            return (LoggedInAdministratorFacade)LoginIFacade;
        }
        [ResponseType(typeof(AirlineCompany))]
        [HttpPost]
        [Route ("api/AdministratorFacadeController/CreateNewAirline")]
        public IHttpActionResult CreateNewAirline([FromBody]AirlineCompany airline)
        {
            try
            {
                getAdminLoginToken().CreateNewAirline(adminLoginToken, airline);
                //LoginToken<Administrator> adminToken = help.getLoginToken();
                //adminFacade.CreateNewAirline(adminToken, airline);
                return Ok(airline);
            }
            catch (Exception e)
            {
                if (airline == null)
                    return BadRequest(e.Message);
                return BadRequest(e.Message);
            }
        }

        [ResponseType(typeof(void))]
        [HttpPut]
        [Route("api/AdministratorFacadeController/UpdateAirline")]
        public IHttpActionResult UpdateAirlineDetails(AirlineCompany airline)
        {
            try
            {
                getAdminLoginToken().UpdateAirlineDetails(adminLoginToken, airline);
                return Ok();
            }
            catch (Exception e)
            {
                if (airline == null || adminFacade.GetAirlineByUserame(airline.USER_NAME) == null)
                    return BadRequest("This airline can not be found!");
                return BadRequest(e.Message);
            } 
        }

        [ResponseType(typeof(void))]
        [HttpDelete]
        [Route("api/AdministratorFacadeController/RemoveAirline")]
        public IHttpActionResult RemoveAirline(AirlineCompany airline)
        {
            try
            {
                getAdminLoginToken().RemoveAirline(adminLoginToken, airline);
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception e)
            {
                if (airline == null || adminFacade.GetAirlineByUserame(airline.USER_NAME) == null)
                    return BadRequest("The specific airline can not be found!");
                return BadRequest(e.Message);
            }
        }

        [ResponseType(typeof(Customer))]
        [HttpPost]
        [Route("api/AdministratorFacadeController/CreateNewCustomer")]
        public IHttpActionResult CreateNewCustomer(Customer customer)
        {
            try
            {
                getAdminLoginToken().CreateNewCustomer(adminLoginToken, customer);
                return Ok("Account created successfully");
            }
            catch (Exception e)
            {
                if (customer == null)
                    return BadRequest("Bad info was given! ");
                return BadRequest(e.Message);
            } 
        }

        [ResponseType(typeof(Customer))]
        [Route("api/AdministratorFacadeController/UpdateCusomterDetails")]
        [HttpPut]
        public IHttpActionResult UpdateCustomerDetails(Customer customer)
        {
            try
            {
                getAdminLoginToken().UpdateCustomerDetails(adminLoginToken, customer);
                return Ok();
            }
            catch (Exception e)
            {
                if (customer == null)
                    return BadRequest("Bad info was given");
                return BadRequest(e.Message);
            }
        }

        [ResponseType(typeof(void))]
        [HttpDelete]
        [Route("api/AdministratorFacadeController/RemoveCustomer")]
        public IHttpActionResult RemoveCustomer(Customer customer)
        {
            try
            {
                getAdminLoginToken().RemoveCustomer(adminLoginToken, customer);
                return Ok();
            }
            catch (Exception e)
            {
                if (customer == null)
                    return BadRequest("Bad info was given");
                return BadRequest(e.Message);
            }
        }
    }
}
