using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainProject;

namespace part2
{
    public class DBCustomers
    {
        public List<Customer> customers;

        public List<Customer> CreateCustomers()
        {
            customers= new List<Customer>();
            customers.Add(new Customer
            {
                FIRST_NAME = "Kobi",
                LAST_NAME = "Ohana",
                USER_NAME = "Kobij",
                PASSWORD = "k789j654",
                ADDRESS = "Ben Gurion 152, Tel Aviv",
                PHONE_NO = "05044558795",
                CREDIT_CARD_NUMBER = "4580115523451524"
            });
            customers.Add(new Customer
            {
                FIRST_NAME = "Itay",
                LAST_NAME = "Rage",
                USER_NAME = "ItsItay1",
                PASSWORD = "Eat456789",
                ADDRESS = "Shaul Hamelech 4, Kfar Sava",
                PHONE_NO = "0542244515",
                CREDIT_CARD_NUMBER = "4580457812456521"
            });
            customers.Add(new Customer
            {
                FIRST_NAME = "Koral",
                LAST_NAME = "Kanot",
                USER_NAME = "Koral23",
                PASSWORD = "Kk100100",
                ADDRESS = "Sheshet Hayamim 454, Jerusalem",
                PHONE_NO = "0552121458",
                CREDIT_CARD_NUMBER = "5245121254875566"
            });
            customers.Add(new Customer
            {
                FIRST_NAME = "David",
                LAST_NAME = "Goldstein",
                USER_NAME = "DavidG4",
                PASSWORD = "Dg240592",
                ADDRESS = "Havaselet 24 , Haifa",
                PHONE_NO = "0504548215",
                CREDIT_CARD_NUMBER = "32514524"
            });
            customers.Add(new Customer
            {
                FIRST_NAME = "Jamy",
                LAST_NAME = "Yan",
                USER_NAME = "JamyYan654",
                PASSWORD = "J0506644521",
                ADDRESS = "Havradim 74 , Tel Aviv",
                PHONE_NO = "0544875542",
                CREDIT_CARD_NUMBER = "4125654215487878"
            });
            customers.Add(new Customer
            {
                FIRST_NAME = "Gilad",
                LAST_NAME = "Malinsky",
                USER_NAME = "gilad123",
                PASSWORD = "GILADm45",
                ADDRESS = "Yeffe Nof 24, Pardes Hanna",
                PHONE_NO = "0524578512",
                CREDIT_CARD_NUMBER = "5326545412124578"
            });
            customers.Add(new Customer
            {
                FIRST_NAME = "Amit",
                LAST_NAME = "Sheftel",
                USER_NAME = "amitsh8",
                PASSWORD = "amam123456",
                ADDRESS = "Haim 45, Naharya",
                PHONE_NO = "05578455521",
                CREDIT_CARD_NUMBER = "4587854621548752"
            });
            customers.Add(new Customer
            {
                FIRST_NAME = "Lital",
                LAST_NAME = "Jerbi",
                USER_NAME = "Lital4j",
                PASSWORD = "Jer55442211",
                ADDRESS = "Tapuz 51, Yokneam",
                PHONE_NO = "05287545663",
                CREDIT_CARD_NUMBER = "1212454578785656"
            });
            customers.Add(new Customer
            {
                FIRST_NAME = "Ayelet",
                LAST_NAME = "Sharon",
                USER_NAME = "ayel51hs",
                PASSWORD = "ayayshsh654",
                ADDRESS = "Perach 15, Yehud",
                PHONE_NO = "0585245124",
                CREDIT_CARD_NUMBER = "4456778911234456"
            });
            customers.Add(new Customer
            {
                FIRST_NAME = "Ilan",
                LAST_NAME = "Haver",
                USER_NAME = "ilanHaver4447",
                PASSWORD = "4447Ilan123",
                ADDRESS = "Hatazpit 252, Kineret",
                PHONE_NO = "0532154236",
                CREDIT_CARD_NUMBER = "6655447788996655"
            });
            return customers;
        }
    }
}
