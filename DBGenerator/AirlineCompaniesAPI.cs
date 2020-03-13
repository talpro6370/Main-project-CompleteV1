using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    public class AirlineCompaniesAPI
    {
        private string airline_name { get; set; }
        public string Airline_Name
        {
            get
            {
                return airline_name;
            }
            set
            {
                this.airline_name = value;
            }
        }
        public string user_name { get; set; }
        public string User_Name
        {
            get
            {
                return user_name;
            }
            set
            {
                this.user_name = value;
            }
        }

        public string password { get; set; }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                this.password = value;
            }
        }
        public long country_code { get; set; }
        public long Country_Code
        {
            get
            {
                return country_code;
            }
            set
            {
                this.country_code = value;
            }
        }

    }
}
