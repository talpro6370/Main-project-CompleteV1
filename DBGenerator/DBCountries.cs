using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject;
namespace part2
{
    public class DBCountries
    {
        public List<Country> countries;
        public List<Country> CreateCountries()
        {
            countries = new List<Country>();
            countries.Add(new Country { COUNTRY_NAME = "Israel" });
            countries.Add(new Country { COUNTRY_NAME = "England" });
            countries.Add(new Country { COUNTRY_NAME = "Turkey" });
            countries.Add(new Country { COUNTRY_NAME = "Netherlands " });
            countries.Add(new Country { COUNTRY_NAME = "Egypt" });
            countries.Add(new Country { COUNTRY_NAME = "Denemark" });
            countries.Add(new Country { COUNTRY_NAME = "Cyprus" });
            countries.Add(new Country { COUNTRY_NAME = "Croatia" });
            countries.Add(new Country { COUNTRY_NAME = "Germany" });
            countries.Add(new Country { COUNTRY_NAME = "Italy" });
            countries.Add(new Country { COUNTRY_NAME = "Greece" });
            countries.Add(new Country { COUNTRY_NAME = "China" });
            countries.Add(new Country { COUNTRY_NAME = "Japan" });
            countries.Add(new Country { COUNTRY_NAME = "Thailand" });
            countries.Add(new Country { COUNTRY_NAME = "Iraq" });
            countries.Add(new Country { COUNTRY_NAME = "Libya" });
            countries.Add(new Country { COUNTRY_NAME = "Jordan" });
            countries.Add(new Country { COUNTRY_NAME = "Mexico" });
            countries.Add(new Country { COUNTRY_NAME = "Panama" });
            countries.Add(new Country { COUNTRY_NAME = "France" });
            countries.Add(new Country { COUNTRY_NAME = "Prauge" });
            countries.Add(new Country { COUNTRY_NAME = "Serbia" });
            countries.Add(new Country { COUNTRY_NAME = "Romania" });
            countries.Add(new Country { COUNTRY_NAME = "Senegal" });
            countries.Add(new Country { COUNTRY_NAME = "India" });
            countries.Add(new Country { COUNTRY_NAME = "Sweden" });
            countries.Add(new Country { COUNTRY_NAME = "Yemen" });
            return countries;
        }
    }   
        
}