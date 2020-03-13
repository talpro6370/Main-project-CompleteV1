using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using MainProject;
using MainProject.Business_Logic;
namespace part2
{
    [JsonObjectAttribute]
    public class WorkWithAPI
    {
        private LoggedInAirlineFacade airlineFacade = new LoggedInAirlineFacade();
        private List<Country> randomCountries = new List<Country>();
        private List<Country> convertedArray = new List<Country>();
        private List<AirlineCompany> airlines = new List<AirlineCompany>();
        private List<AirlineCompany> returnAirlines = new List<AirlineCompany>();
        private List<Customer> randomCustomers = new List<Customer>();
        private List<Customer> returnCustomers = new List<Customer>();
        static string countriesUrl = "https://restcountries.eu/rest/v2";
        static string customersUrl = "https://my.api.mockaroo.com/mainprojcustomerapi.json/users?key=a2b3f880";
        static string airlineCompaniesUrl = "https://my.api.mockaroo.com/airlinecompaniesapi.json/airlineCompanies?key=a2b3f880";
        public List<Country> CountriesApiWebWork()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(countriesUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("").Result; 
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<CountriesAPI>>().Result;
                Random rnd = new Random();
                int index = rnd.Next(dataObjects.Count());
                foreach (var d in dataObjects)
                {
                    convertedArray.Add(new Country(d.Name));
                }
                for (int i = 0; i < dataObjects.Count(); i++)
                {
                    randomCountries.Add(convertedArray[i]);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return randomCountries; 
        }
        
        public List<Customer> CustomerApiWork()
        {
            HttpClient client = new HttpClient();
            
            client.BaseAddress = new Uri(customersUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<CustomersAPI>>().Result;
                foreach (var customer in dataObjects)
                {
                    randomCustomers.Add(new Customer(customer.First_Name,customer.Last_Name,customer.User_Name,customer.Password,customer.Address,customer.Phone_No,customer.Credit_Card));
                }
                for (int i = 0; i < dataObjects.Count(); i++)
                {
                    returnCustomers.Add(randomCustomers[i]);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return returnCustomers;
        }
        public List<AirlineCompany> AirlineCompnyApiWork()
        {

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(airlineCompaniesUrl);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<AirlineCompaniesAPI>>().Result;
                foreach (var airline in dataObjects)
                {
                    airlines.Add(new AirlineCompany(airline.Airline_Name,airline.user_name,airline.password,airlineFacade.GetRandomCountryId()));
                }
                for (int i = 0; i < dataObjects.Count(); i++)
                {
                    returnAirlines.Add(airlines[i]);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            return returnAirlines;
        }
    }
}
