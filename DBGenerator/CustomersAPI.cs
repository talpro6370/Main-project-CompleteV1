using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    public class CustomersAPI
    {
        private string first_name { get; set; }
        private string last_name { get; set; }
        private string user_name { get; set; }
        private string password { get; set; }
        private string address { get; set; }
        private string phone_no { get; set; }
        private string credit_card { get; set; }
        public string First_Name
        {
            get
            {
                return first_name;
            }
            set
            {
                this.first_name = value;
            }
        }
        public string Last_Name
        {
            get
            {
                return last_name;
            }
            set
            {
                this.last_name= value;
            }
        }
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
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                this.password= value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                this.address= value;
            }
        }
        public string Phone_No
        {
            get
            {
                return phone_no;
            }
            set
            {
                this.phone_no= value;
            }
        }
        public string Credit_Card
        {
            get
            {
                return credit_card;
            }
            set
            {
                this.credit_card = value;
            }
        }
    }
}
