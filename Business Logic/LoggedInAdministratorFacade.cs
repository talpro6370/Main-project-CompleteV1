using MainProject.DAO;
using MainProject.InterFaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Business_Logic
{
    public class LoggedInAdministratorFacade : AnonymousUserFacade, ILoggedInAdministratorFacade, IFacade
    {
        public void CreateNewAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (token != null)
            {
                _airlineDAO = new AirLineDAOMSSQL();
                _airlineDAO.Add(airline);
            }
        }

        public void CreateNewCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (token != null)
            {
                _customerDAO = new CustomerDAOMSSQL();
                _customerDAO.Add(customer);
            }
        }

        public void RemoveAirline(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (token != null)
            {
                _airlineDAO = new AirLineDAOMSSQL();
                _airlineDAO.Remove(airline);
            }
        }

        public void RemoveCustomer(LoginToken<Administrator> token, Customer customer)
        {
            if (token != null)
            {
                _customerDAO = new CustomerDAOMSSQL();
                _customerDAO.Remove(customer);
            }
        }

        public void UpdateAirlineDetails(LoginToken<Administrator> token, AirlineCompany airline)
        {
            if (token != null)
            {
                _airlineDAO = new AirLineDAOMSSQL();
                _airlineDAO.Update(airline);
            }
        }

        public void UpdateCustomerDetails(LoginToken<Administrator> token, Customer customer)
        {
            if (token != null)
            {
                _customerDAO = new CustomerDAOMSSQL();
                _customerDAO.Update(customer);
            }
        }
        public void CreateNewCountry(LoginToken<Administrator> token, Country country)
        {
            if (token != null)
            {
                _countryDAO = new CountryDAOMSSQL();
                _countryDAO.Add(country);
            }
        }
        public long GetCountryId(string countryName)
        {
            _countryDAO = new CountryDAOMSSQL();
            return _countryDAO.GetCountryId(countryName);
        }
        public AirlineCompany GetAirlineByUserame(string name)
        {
            _airlineDAO = new AirLineDAOMSSQL();
            return _airlineDAO.GetAirlineByUserame(name);
        }
        public Customer GetCustomerByUserName(string userName)
        {
            _customerDAO = new CustomerDAOMSSQL();
            return _customerDAO.GetCustomerByUserame(userName);
        }
        public void AddTicketsToCustomer(LoginToken<Administrator> token,long customerId,long flightId)
        {
            _ticketDAO = new TicketDAOMSSQL();
            Tickets ticket = new Tickets(customerId, flightId);
            _ticketDAO.Add(ticket);
        }

        public void AddTicket(Tickets ticket)
        {
            _ticketDAO = new TicketDAOMSSQL();
            _ticketDAO.Add(ticket);
        }
    }

}
