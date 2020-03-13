using MainProject;
using MainProject.Business_Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApiPart.Controllers.BasicAuthAtt;

namespace WebApiPart.Controllers
{
    [BasicAirlineAuthenticationAttribute]
    public class CompanyFacadeController : ApiController
    {
        LoginToken<AirlineCompany> companyToken;
        private LoggedInAirlineFacade airlineCompanyFacade = new LoggedInAirlineFacade();
        Models.LoginHelpClass helpClass = new Models.LoginHelpClass();

        public LoggedInAirlineFacade getCompanyLoginToken()
        {
            Request.Properties.TryGetValue("airlineCompany-login-token", out object loginUser);
            companyToken = (LoginToken<AirlineCompany>)loginUser;
            FacadeBase LoginIFacade = FlyingCenterSystem.GetInstance().GetFacade(companyToken);
            return (LoggedInAirlineFacade)LoginIFacade;
        }

        [ResponseType(typeof(List<Tickets>))]
        [Route("api/CompanyFacade/GetAllTickets")]
        [HttpGet]
        public IHttpActionResult GetAllTickets()
        {
            try
            {
                if (getCompanyLoginToken().GetAllTickets(companyToken)==null)
                    return NotFound();
                return Ok(airlineCompanyFacade.GetAllTickets(companyToken));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message.ToString());
            }
        }
        [ResponseType(typeof(List<Flight>))]
        [Route("api/CompanyFacade/GetAllFlights")]
        [HttpGet]
        public IHttpActionResult GetAllFlights()
        {
            try
            {
                if (airlineCompanyFacade.GetAllFlights() == null)
                    return NotFound();
                return Ok(airlineCompanyFacade.GetAllFlights());

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IHttpActionResult CancelFlight(Flight flight)
        {
            try
            {
                LoginToken<AirlineCompany> airlineToken = helpClass.GetAirlineToken();
                if (airlineCompanyFacade.GetFlightById((int)flight.ID) == null)
                    return NotFound();
                airlineCompanyFacade.CancelFlight(airlineToken, flight);
                return Ok(airlineCompanyFacade.GetFlightById((int)flight.ID));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [Route("api/CreateNewFlight")]
        [HttpPost]
        public IHttpActionResult CreateFlight(Flight flight)
        {
            LoginToken<AirlineCompany> airlineToken = new LoginToken<AirlineCompany>();
            try
            {
                airlineCompanyFacade.CreateFlight(airlineToken, flight);
                return Ok(flight);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }
        [Route("api/UpdateFlight")]
        [HttpPut]
        public IHttpActionResult UpdateFlight(Flight flight)
        {
            try
            {
                LoginToken<AirlineCompany> airlineToken = new LoginToken<AirlineCompany>();
                airlineCompanyFacade.UpdateFlight(airlineToken, flight);
                return Ok(flight);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }

        }
        [Route("api/airlinePasswordChange")]
        [HttpPut]
        public IHttpActionResult ChangeMyPassword(string userName, string newPassword)
        {
            LoginToken<AirlineCompany> airlineToken = new LoginToken<AirlineCompany>();
            try
            {
                airlineCompanyFacade.ChangeMyPassword(airlineToken, userName, newPassword);
                return Ok("The password has been changed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult MofidyAirlineDetails(AirlineCompany airline)
        {
            LoginToken<AirlineCompany> airlineToken = new LoginToken<AirlineCompany>();
            try
            {
                airlineCompanyFacade.MofidyAirlineDetails(airlineToken,airline);
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
