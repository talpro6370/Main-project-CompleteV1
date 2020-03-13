using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Pocos
{
    public class CustomerRegistraionInfo
    {
        private string firstName;
        private string lastName;
        private string userName;
        private string password;
        private string email;
        private string address;
        private string phoneNo;
        private string creditCardNumber;

        public string FIRST_NAME { get {return firstName; } set { this.firstName = value; } }
        public string LAST_NAME { get { return lastName; } set { this.lastName = value; } }
        public string USER_NAME { get { return userName; } set { this.userName = value; } }
        public string PASSWORD { get { return password; } set { this.password = value; } }
        public string Email { get { return email; } set { this.email = value; } }
        public string ADDRESS { get { return address; } set { this.address = value; } }
        public string PHONE_NO { get { return phoneNo; } set { this.phoneNo = value; } }
        public string CREDIT_CARD_NUMBER { get { return creditCardNumber; } set { this.creditCardNumber = value; } }

        public CustomerRegistraionInfo()
        {

        }
    }
}
