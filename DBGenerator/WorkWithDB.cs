using MainProject;
using MainProject.Business_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace part2
{
    public class WorkWithDB
    {
        public LoggedInAirlineFacade alf = new LoggedInAirlineFacade();
        public LoggedInAdministratorFacade afc = new LoggedInAdministratorFacade();
        public LoggedInCustomerFacade cfc = new LoggedInCustomerFacade();
        public LoginToken<Administrator> adninToken = new LoginToken<Administrator>();
        public LoginToken<AirlineCompany> airlineToken = new LoginToken<AirlineCompany>();
        public LoginToken<Customer> customerToken = new LoginToken<Customer>();
        public List<Country> countries;
        public List<Customer> customers;
        public List<AirlineCompany> airlineCompanies;
        public List<Tickets> ticketsPerCustomer;
        public List<Flight> flightsPerCompany;
        public int numberOfFlightsToCreate = 0;
        public WorkWithAPI restWorking;
        public event PropertyChangedEventHandler PropertyChanged;
        private BackgroundWorker _bgWorker;
        public int proggressBarVal { get; set; }
        public int proggressBarMaxVal { get; set; }
        public int ProggressBarMaxVal
        {
            get
            {
                return proggressBarMaxVal;
            }
            set
            {
                this.proggressBarMaxVal = value;
                OnPropertyChanged("ProggressBarMaxVal");
            }
        }
        public int ProggressBarVal
        {
            get
            {
                return proggressBarVal ;
            }
            set
            {
                this.proggressBarVal = value;
                OnPropertyChanged("ProggressBarVal");
            }
        }
        private int _progressStatus;
        public int ProgressStatus
        {
            get
            {
                return _progressStatus;
            }
            set
            {
                this._progressStatus = value;
                OnPropertyChanged("ProgressStatus");
            }
        }
        public WorkWithDB()
        {
            _bgWorker = new BackgroundWorker();

        }
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public async Task InsertingDataBase(string AirlineNo, string CustomerNo, string FlightsPerCmpnyNo, string TicketsPerCustNo, string CountriesNo)
        {
            _bgWorker.DoWork += (s, e) =>
             {
                 for (int i = 0; i < 101; i++)
                 {
                     Thread.Sleep(100);
                     ProgressStatus = i;
                 }
             };
            _bgWorker.RunWorkerAsync();
            int numberOfAirLines = Int32.Parse(AirlineNo);
            int numberOfCustomers = Int32.Parse(CustomerNo);
            int numberOfFlightsPerCmp = Int32.Parse(FlightsPerCmpnyNo);
            int numberOfTicketsPerCust = Int32.Parse(TicketsPerCustNo);
            int numberOfCountries = Int32.Parse(CountriesNo);
            try
            {
                await Task.Run(() => 
                {
                    restWorking = new WorkWithAPI();
                    List<Country> countriesFromRest = restWorking.CountriesApiWebWork();
                    int countryNoParsed = Convert.ToInt32(CountriesNo);
                    int customerNoParsed = Convert.ToInt32(CustomerNo);
                    int flightNoParsed = Convert.ToInt32(FlightsPerCmpnyNo);
                    int airlineNoParsed = Convert.ToInt32(AirlineNo);
                    int ticketNoParsed = Convert.ToInt32(TicketsPerCustNo);
                    ProggressBarMaxVal = countryNoParsed + customerNoParsed + flightNoParsed + airlineNoParsed + ticketNoParsed;
                    for (int i = 0; i <countryNoParsed; i++)
                    {
                        afc.CreateNewCountry(new LoginToken<Administrator>(), countriesFromRest[i]);
                        ProggressBarVal += i;
                    }
                    
                    List<AirlineCompany> airlines = restWorking.AirlineCompnyApiWork();
                    for (int i = 0; i < airlineNoParsed; i++)
                    {
                        afc.CreateNewAirline(new LoginToken<Administrator>(), airlines[i]);
                        ProggressBarVal += i;
                    }

                    List<Customer> customersREST = restWorking.CustomerApiWork();
                    for (int i = 0; i < customerNoParsed; i++)
                    {
                        afc.CreateNewCustomer(new LoginToken<Administrator>(), customersREST[i]);
                        ProggressBarVal += i;
                    }
                    flightsPerCompany = new List<Flight>();
                    long airlineId = 0;
                    long countryCode = 0;
                    string airlineName = null;
                    long secondCountryCode = 0;
                    DateTime firstDate = new DateTime();
                    DateTime secondDate = new DateTime();
                    numberOfFlightsToCreate = RandomFlightToBeCreated();
                    for (int j = 0; j < airlineNoParsed; j++)
                    {
                        for (int i = 0; i < flightNoParsed; i++)
                        {
                            airlineId = alf.GetRandomAirlineId();
                            airlineName = alf.GetAirlineNameByID((int)airlineId);
                            countryCode = alf.GetRandomCountryId();
                            secondCountryCode = alf.GetRandomCountryId();
                            firstDate = RandomDate();
                            Thread.Sleep(10);
                            secondDate = RandomDate2(firstDate);
                            flightsPerCompany.Add(new Flight(airlineId, countryCode, secondCountryCode, firstDate, secondDate, RandomTickets(), airlineName, RandomString()));
                            ProggressBarVal += i;
                        }
                    }
                    
                    foreach (var flight in flightsPerCompany)
                    {
                        alf.CreateFlight(airlineToken, flight);
                    }
                    Random rnd = new Random();
                    int numberOfIds = 0,flightID=0;
                    List<long> customerIds = cfc.GetAllCustomerID();
                    LoginService customerLogin = new LoginService();

                    for (int i = 0; i < customerNoParsed; i++)
                    {
                        for (int j = 0; j < ticketNoParsed; j++)
                        {
                            numberOfIds = rnd.Next(flightNoParsed);
                            Tickets ticket = new Tickets();
                            customerLogin.TryCustomerLogin(restWorking.CustomerApiWork()[i].USER_NAME, restWorking.CustomerApiWork()[i].PASSWORD, out customerToken);
                            flightID = (int)alf.GetRandomFlightID();
                            ticket = cfc.PurchaseTicket(customerToken, afc.GetFlightById(flightID));
                            ticket.CUSTOMER_ID = customerIds[i];
                            ticket.FLIGHT_ID = flightID;
                            afc.AddTicket(ticket);
                            ProggressBarVal += j;
                        }
                    }
                    
                });
                
            }
            catch (Exception )
            {
                throw new Exception("Something went wrong while trying to insert data...");
            }
        }
        public void RemoveDB()
        {
            FlightCenterConfig.DeleteDataBase();
        }
        public int RandomTickets()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(0, 10);
            return randomNumber;
        }
        public int RandomFlightToBeCreated()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(1, 10);
            return randomNumber;
        }
        public DateTime RandomDate()
        {
            Random gen = new Random();
            DateTime start = DateTime.Today;
            return start.AddHours(gen.Next(0, 12)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }
        public DateTime RandomDate2(DateTime date)
        {
            
            Random gen = new Random();
            Random randomHours = new Random();
            randomHours.Next(12); //max hours of flight
            DateTime start = date;
            return start.AddHours(randomHours.Next(0, 24));
        }
        public string RandomString()
        {
            Random random = new Random();
            int length = 10;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new String(stringChars);
        }
        public TaskStatus DbStatus()
        {
            Task.WaitAll();
            return Task.CompletedTask.Status;
        }
    }
}
