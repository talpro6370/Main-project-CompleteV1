using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject;
using MainProject.Business_Logic;

namespace part2
{
    public class DBAirlineCompanies
    {
        public List<AirlineCompany> companies;
        public LoggedInAirlineFacade alf = new LoggedInAirlineFacade();
        public List<AirlineCompany> CreateCompanies()
        {
            
            companies = new List<AirlineCompany>();
            companies.Add(new AirlineCompany
            {
                AIRLINE_NAME = "El Al",
                USER_NAME = "ElAl789",
                PASSWORD = "elA789",
                COUNTRY_CODE = alf.GetRandomCountryId()
            });
            companies.Add(new AirlineCompany
            {
                AIRLINE_NAME = "MaroccoAir",
                USER_NAME = "M78",
                PASSWORD = "ms651",
                COUNTRY_CODE = alf.GetRandomCountryId()
                
            });
            companies.Add(new AirlineCompany
            {
                AIRLINE_NAME = "Four4real",
                USER_NAME = "Fori44",
                PASSWORD = "1f5611",
                COUNTRY_CODE = alf.GetRandomCountryId()
                
            });
            companies.Add(new AirlineCompany
            {
                AIRLINE_NAME = "Jambo AirLine",
                USER_NAME = "Jambo27",
                PASSWORD = "j456s7",
                COUNTRY_CODE = alf.GetRandomCountryId()
                
            });
            companies.Add(new AirlineCompany
            {
                AIRLINE_NAME = "Ponnies",
                USER_NAME = "PonyTail21",
                PASSWORD = "T758421",
                COUNTRY_CODE = alf.GetRandomCountryId()
                
            });
            companies.Add(new AirlineCompany
            {
                AIRLINE_NAME = "Sea Esta",
                USER_NAME = "Beach99",
                PASSWORD = "beach61123",
                COUNTRY_CODE = alf.GetRandomCountryId()
                
            });
            companies.Add(new AirlineCompany
            {
                AIRLINE_NAME = "Rolland lines",
                USER_NAME = "Roll53",
                PASSWORD = "rlnsn45",
                COUNTRY_CODE = alf.GetRandomCountryId()
                
            });
            companies.Add(new AirlineCompany
            {
                AIRLINE_NAME = "Turkish AirLines",
                USER_NAME = "Turk131",
                PASSWORD = "tutu45",
                COUNTRY_CODE = alf.GetRandomCountryId()
                
            });
            companies.Add(new AirlineCompany
            {
                AIRLINE_NAME = "Kebaba Lines",
                USER_NAME = "Bikjs",
                PASSWORD = "kindj787",
                COUNTRY_CODE = alf.GetRandomCountryId()
                
            });
            companies.Add(new AirlineCompany
            {
                AIRLINE_NAME = "Ironia Air",
                USER_NAME = "airf64",
                PASSWORD = "airOnia88",
                COUNTRY_CODE = alf.GetRandomCountryId()
                
            });
            return companies;
        }
    }
}
