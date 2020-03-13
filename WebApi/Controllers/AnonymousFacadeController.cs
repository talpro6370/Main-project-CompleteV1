using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MainProject;
using MainProject.Business_Logic;
using MainProject.Pocos;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace WebApiPart.Controllers
{
    public class AnonymousFacadeController : ApiController
    {

        private AnonymousUserFacade anonymousUser = new AnonymousUserFacade();

        [ResponseType(typeof(List<Flight>))]
        [Route("api/AnonymousFacade/GetAllFlights")]
        [HttpGet]
        public IHttpActionResult GetAllFlights()
        {
            if (anonymousUser.GetAllFlights() == null)
                return NotFound();
            return Ok(anonymousUser.GetAllFlights());
        }

        [ResponseType(typeof(List<AirlineCompany>))]
        [Route("api/AnonymousFacade/GetAllAirlines")]
        [HttpGet]
        public IHttpActionResult GetAllAirlineCompanies()
        {
            if (anonymousUser.GetAllAirlineCompanies() == null)
                return NotFound();
            return Ok(anonymousUser.GetAllAirlineCompanies());
        }
        [ResponseType (typeof(Dictionary<Flight, int>))]
        [Route ("api/AnonymousFacade/GetAllFlightVacancy")]
        [HttpGet]
        public IHttpActionResult GetAllFlightsVacancy()
        {
            if (anonymousUser.GetAllFlightsVacancy() == null)
                return NotFound();
            return Ok(anonymousUser.GetAllFlightsVacancy());
        }
        [ResponseType (typeof(Flight))]
        [Route("api/AnonymousFacade/{id}",Name ="GetFlightById")]
        [HttpGet]
        public IHttpActionResult GetFlightById(int id)
        {
            if (anonymousUser.GetFlightById(id) == null)
                return NotFound();
            return Ok(anonymousUser.GetFlightById(id));
        }
        [ResponseType(typeof(Flight))]
        [Route("api/AnonymousFacade/GetFlightsByOrigCountry")]
        [HttpGet]
        public IHttpActionResult GetFlightsByOriginCountry(int countryCode)
        {
            if (anonymousUser.GetFlightsByOriginCountry(countryCode) == null)
                return NotFound();
            return Ok((anonymousUser.GetFlightsByOriginCountry(countryCode)));
        }

        [ResponseType(typeof(Flight))]
        [Route("api/AnonymousFacade/GetFlightsByDesCountry")]
        [HttpGet]
        public IHttpActionResult GetFlightsByDestinationCountry(int countryCode)
        {
            if (anonymousUser.GetFlightsByDestinationCountry(countryCode) == null)
                return NotFound();
            return Ok((anonymousUser.GetFlightsByDestinationCountry(countryCode)));
        }
        [ResponseType(typeof(Flight))]
        [Route("api/AnonymousFacade/GetFlightsByDepDate")]
        [HttpGet]
        IHttpActionResult GetFlightsByDepatrureDate(DateTime departureDate)
        {
            if (anonymousUser.GetFlightsByDepatrureDate(departureDate) == null)
                return NotFound();
            return Ok((anonymousUser.GetFlightsByDepatrureDate(departureDate)));
        }
        [ResponseType(typeof(Flight))]
        [Route("api/AnonymousFacade/GetFlightsByLandDate")]
        [HttpGet]
        public IHttpActionResult GetFlightsByLandingDate(DateTime landingDate)
        {
            if (anonymousUser.GetFlightsByLandingDate(landingDate) == null)
                return NotFound();
            return Ok((anonymousUser.GetFlightsByLandingDate(landingDate)));
        }
        [ResponseType(typeof(DeparturesPoco))]
        [Route("api/AnonymousFacade/GetDepartureDetails")]
        [HttpGet]
        public IHttpActionResult GetDepartureDetails()
        {
            if (anonymousUser.GetDepartureDetails() == null)
                return NotFound();
            return Ok(anonymousUser.GetDepartureDetails());
        }
        [ResponseType(typeof(ArrivalsPoco))]
        [Route("api/AnonymousFacade/GetArrivalsDetails")]
        [HttpGet]
        public IHttpActionResult GetArrivalsDetails()
        {
            if (anonymousUser.GetArrivalsDetails() == null)
                return NotFound();
            return Ok(anonymousUser.GetArrivalsDetails());
        }
         
        [Route("api/AnonymousFacade/Search")]
        [HttpGet]
        public IHttpActionResult GetByFilter(string airline = "", string destination = "", string origin = "", int flight = 0)
        {
            try
            {
                if (!string.IsNullOrEmpty(airline))
                {
                    airline = airline.TrimStart();
                    return Ok(anonymousUser.GetFlightsByAirlineName(airline));
                }
                if (!string.IsNullOrEmpty(destination))
                {
                    destination = destination.TrimStart();
                    return Ok(anonymousUser.GetFlightsByDesCountryNameFromDb(destination));
                }
                if (!string.IsNullOrEmpty(origin))
                {
                    origin = origin.TrimStart();
                    return Ok(anonymousUser.GetFlightsByOriginCountryName(origin));

                }
                if (flight > 0)
                {
                        return Ok(anonymousUser.GetFlightsByFlightNum(flight));
                }

            }
            catch (Exception )
            {
                
            }
            
            return BadRequest("The details you entered are not correct.");

        }
        //[ResponseType(typeof(Customer))]
        [HttpPost]
        [Route("api/AnonymousFacade/CreateNewCustomer")]
        public IHttpActionResult CreateNewCustomer(CustomerRegistraionInfo customerInfo)
        {
            Customer customer = new Customer()
            {
                FIRST_NAME = customerInfo.FIRST_NAME,
                LAST_NAME = customerInfo.LAST_NAME,
                USER_NAME = customerInfo.USER_NAME,
                PASSWORD = customerInfo.PASSWORD,
                ADDRESS = customerInfo.ADDRESS,
                PHONE_NO = customerInfo.PHONE_NO,
                CREDIT_CARD_NUMBER = customerInfo.CREDIT_CARD_NUMBER
            };
            try
            {
                CustomerMvcController cus = new CustomerMvcController();
                anonymousUser.CreateNewCustomer(customer);
                cus.Email(customerInfo);
                return Ok("Account created successfully! Please verify your email");
            }
            catch (Exception e)
            {
                if (customer == null)
                    return BadRequest("Bad info was given! ");
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("api/AnonymousFacade/CheckCustLogin")]
        public IHttpActionResult CheckCustLogin(Customer customerInfo)
        {
            Customer cust = new Customer();
            if(customerInfo!=null)
            {
                cust = anonymousUser.CheckCustLogin(customerInfo);
                if (cust.USER_NAME == customerInfo.USER_NAME && cust.PASSWORD == customerInfo.PASSWORD)
                {
                    return Ok(cust);
                }
                return Ok("");
            }
            return BadRequest("The details you entered are incorrect");
        }

    }
}
