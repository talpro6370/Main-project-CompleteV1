using MainProject.DAO;
using MainProject.InterFaces;
using MainProject.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Business_Logic
{
    public class AnonymousUserFacade : FacadeBase, IAnonymousUserFacade , ILoginTokenBase
    {
        public List<AirlineCompany> GetAllAirlineCompanies()
        {
            _airlineDAO = new AirLineDAOMSSQL();
            return _airlineDAO.GetAll();   
        }

        public List<Flight> GetAllFlights()
        {
            _flightDAO = new FlightDAOMSSQL();
            return _flightDAO.GetAll();
        }

        public Dictionary<Flight, int> GetAllFlightsVacancy()
        {
            _flightDAO = new FlightDAOMSSQL();
            return _flightDAO.GetAllFlightsVacancy();
        }

        public Flight GetFlightById(int id)
        {
            _flightDAO = new FlightDAOMSSQL();
            return _flightDAO.GetFlightById(id);
        }

        public List<Flight> GetFlightsByDepatrureDate(DateTime departureDate)
        {
            _flightDAO = new FlightDAOMSSQL();
            return _flightDAO.GetFlightsByDepatrureDate(departureDate);
        }

        public List<Flight> GetFlightsByDestinationCountry(int countryCode)
        {
            _flightDAO = new FlightDAOMSSQL();
            return _flightDAO.GetFlightsByDestinationCountry(countryCode);
        }

        public List<Flight> GetFlightsByLandingDate(DateTime landingDate)
        {
            _flightDAO = new FlightDAOMSSQL();
            return _flightDAO.GetFlightsByLandingDate(landingDate);
        }

        public List<Flight> GetFlightsByOriginCountry(int countryCode)
        {
            _flightDAO = new FlightDAOMSSQL();
            return _flightDAO.GetFlightsByOriginCountry(countryCode);
        }
        public Tickets GetTicketByFlightId(int id)
        {
            _ticketDAO = new TicketDAOMSSQL();
            return _ticketDAO.GetTicketByFlightId(id);
        }

        public List<DeparturesPoco> GetDepartureDetails()
        {
            _HelperDAO = new HelperDAO();
            return _HelperDAO.DeparturesDetails();
        }
        public List<ArrivalsPoco> GetArrivalsDetails()
        {
            _HelperDAO = new HelperDAO();
            return _HelperDAO.ArrivalsDetails();
        }

        public List<FlightInfoFromDb> GetFlightsByDesCountryNameFromDb(string countryName)
        {
            _HelperDAO = new HelperDAO();
            return _HelperDAO.GetFlightsByDesCountryNameFromDb(countryName);
        }
        public List<CustomerInfoByAirlineName> GetFlightsByAirlineName(string airlineName)
        {
            _HelperDAO = new HelperDAO();
            return _HelperDAO.GetFlightsByAirlineName(airlineName);
        }
        public List<CustomerInfoByAirlineName> GetFlightsByOriginCountryName(string originCountryName)
        {
            _HelperDAO = new HelperDAO();
            return _HelperDAO.GetFlightsByOriginCountryName(originCountryName);
        }
        public List<CustomerInfoByAirlineName> GetFlightsByFlightNum(long flightNum)
        {
            _HelperDAO = new HelperDAO();
            return _HelperDAO.GetFlightsByFlightNum(flightNum);
        }



        public void CreateNewCustomer(Customer customer)
        {
                _customerDAO = new CustomerDAOMSSQL();
                _customerDAO.Add(customer);
            
        }
        public Customer CheckCustLogin(Customer customer)
        {
            _customerDAO = new CustomerDAOMSSQL();
            return _customerDAO.GetCustomerByUserame(customer.USER_NAME);

        }

    }
}
