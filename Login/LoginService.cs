using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject
{
    public class LoginService:ILoginService
    {
        private IAirlineDAO _airlineDAO;
        private ICustomerDAO _customerDAO;
        private Administrator admin = new Administrator();
        public LoginService()
        {
            _airlineDAO = new AirLineDAOMSSQL();
            _customerDAO = new CustomerDAOMSSQL();
        }
        public bool TryAdminLogin(string userName, string password, out LoginToken<Administrator> token)
        {
            try
            {
                if (userName == admin.AdminUserName && password == admin.Password)
                {

                    token = new LoginToken<Administrator>();
                    token.User = new Administrator();
                    token.User.AdminUserName = admin.AdminUserName;
                    token.User.Password = admin.Password;
                    return true;
                }
                else
                {
                    token = null;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            token = null;
            return false;
        }

        public bool TryAirlineLogin(string userName, string password, out LoginToken<AirlineCompany> token)
        {
            try
            {
                _airlineDAO = new AirLineDAOMSSQL();
                AirlineCompany alc = _airlineDAO.GetAirlineByUserame(userName);
                if (alc == null)
                {
                    token = null;
                    return false;
                }
                else if (alc.PASSWORD == password)
                {
                    token = new LoginToken<AirlineCompany>();
                    token.User = new AirlineCompany();
                    token.User.USER_NAME = userName;
                    token.User.PASSWORD = password;
                    return true;
                }
                else if (alc.PASSWORD != password)
                {
                    throw new WrongPasswordException("Wrong password");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            token = null;
            return false;
        }

        public bool TryCustomerLogin(string userName, string password, out LoginToken<Customer> token)
        {
            try
            {
                _customerDAO = new CustomerDAOMSSQL();
                Customer customer = _customerDAO.GetCustomerByUserame(userName);
                if (customer == null)
                {
                    token = null;
                    return false;
                }
                else if (customer.PASSWORD == password)
                {
                    token = new LoginToken<Customer>();
                    token.User = new Customer();
                    token.User.USER_NAME = userName;
                    token.User.PASSWORD = password;
                    return true;
                }
                else if (customer.PASSWORD != password)
                {
                    throw new WrongPasswordException("Wrong password");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            token = null;
            return false;
        }
    }
}
