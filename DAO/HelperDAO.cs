using MainProject.InterFaces;
using MainProject.Pocos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.DAO
{
    public class HelperDAO:IHelperDAO
    {
        public List<DeparturesPoco> DeparturesDetails()
        {
            List<long> destinationCountryCodes = new List<long>();
            List<DeparturesPoco> departures = new List<DeparturesPoco>();
            DeparturesPoco departure;
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
            {
                SqlCommand cmd = new SqlCommand("DepartureDetails", conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    departure = new DeparturesPoco()
                    {
                        estimatedTime = (DateTime)reader["DEPARTURE_TIME"],
                        tickets = (int)reader["REMAINING_TICKETS"],
                        flightName = (string)reader["FLIGHT_NAME"],
                        originFlightLocation = (string)reader["COUNTRY_NAME"],
                        destinationCountryCode = (long)reader["DESTINATION_COUNTRY_CODE"]

                    };
                    destinationCountryCodes.Add(departure.destinationCountryCode);
                    departures.Add(departure);

                }
                cmd.Connection.Close();
            }

            for (int i = 0; i < destinationCountryCodes.Count(); i++)
           
            {
                using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DestinationLocationName", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@countryCode", destinationCountryCodes[i]));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    
                    while (reader.Read()==true)
                    {
                        departures[i].destFlightLocation = (string)reader["COUNTRY_NAME"];
                    }
                    cmd.Connection.Close();
                }
            }
            return departures;
        }
        public List<ArrivalsPoco> ArrivalsDetails()
        {
            List<long> destinationCountryCodes = new List<long>();
            List<ArrivalsPoco> arrivals = new List<ArrivalsPoco>();
            ArrivalsPoco arrival;
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
            {
                SqlCommand cmd = new SqlCommand("ArrivalsDetails", conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    arrival = new ArrivalsPoco()
                    {
                        estimatedTime = (DateTime)reader["LANDING_TIME"],
                        tickets = (int)reader["REMAINING_TICKETS"],
                        flightName = (string)reader["FLIGHT_NAME"],
                        originFlightLocation = (string)reader["COUNTRY_NAME"],
                        destinationCountryCode = (long)reader["ORIGIN_COUNTRY_CODE"],
                    };
                    
                    destinationCountryCodes.Add(arrival.destinationCountryCode);
                    arrivals.Add(arrival);
                    foreach (var flight in arrivals)
                    {
                        if(DateTime.Now.Hour- flight.estimatedTime.Hour>0.25)
                        {
                            flight.status = "landing";
                        }
                        if (DateTime.Now.Hour - flight.estimatedTime.Hour < 0)
                        {
                            flight.status = "landed";
                        }
                        if (DateTime.Now.Hour - flight.estimatedTime.Hour < 2 || DateTime.Now.Hour - flight.estimatedTime.Hour > 0.25)
                        {
                            flight.status = "final";
                        }
                        else
                            flight.status = "not final";
                    }

                }
                cmd.Connection.Close();
            }

            for (int i = 0; i < destinationCountryCodes.Count(); i++)

            {
                using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("DestinationLocationName", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@countryCode", destinationCountryCodes[i]));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                    while (reader.Read() == true)
                    {
                        arrivals[i].destFlightLocation = (string)reader["COUNTRY_NAME"];
                    }
                    cmd.Connection.Close();
                }
            }
            
            return arrivals;
        } 

        public List<FlightInfoFromDb> GetFlightsByDesCountryNameFromDb(string countryName)
        {
            long countryCode = 0;
            List<long> countryCodes = new List<long>();
            string countryNameFin = countryName.ToString();
            List<FlightInfoFromDb> returnList = new List<FlightInfoFromDb>();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCountryCodeByName", conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@countryName", countryName));
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    countryCode = (long)reader["ID"];
                }
                cmd.Connection.Close();
            }
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetFlightsInfoByDestCode", conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@destCountryCode", countryCode));
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    FlightInfoFromDb flight = new FlightInfoFromDb()
                    {
                        flightNum = (long)reader["ID"],
                        originalCountryCode = (long)reader["ORIGIN_COUNTRY_CODE"],
                        departureTime = (DateTime)reader["DEPARTURE_TIME"],
                        landingTime = (DateTime)reader["LANDING_TIME"],
                        tickets = (int)reader["REMAINING_TICKETS"]
                    };
                    returnList.Add(flight);
                }
                cmd.Connection.Close();
            }
            for (int i = 0; i < returnList.Count(); i++)
            {
                using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetAllCountriesNamesByOriCode", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@oriCountryCode", returnList[i].originalCountryCode));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        returnList[i].originFlightLocation = (string)reader["COUNTRY_NAME"];

                    }
                    cmd.Connection.Close();
                }
                foreach (FlightInfoFromDb  flight in returnList)
                {
                    flight.destFlightLocation = countryName;
                }
            }
                return returnList;
        }

        public List<CustomerInfoByAirlineName> GetFlightsByAirlineName(string airlineName)
        {
            List<CustomerInfoByAirlineName> resultInfo = new List<CustomerInfoByAirlineName>();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetFlightInfoByAirlineName", conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@airlineName", airlineName));
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                //ill show u, after this u can see the query inside the ssms
                //this is the reader im talking about..
                while (reader.Read() == true)
                {
                    CustomerInfoByAirlineName flightInfo = new CustomerInfoByAirlineName()
                    {
                        flightNum = (long)reader["ID"],
                        originalCountryCode = (long)reader["ORIGIN_COUNTRY_CODE"],
                        destCountryCode = (long)reader["DESTINATION_COUNTRY_CODE"],
                        departureTime = (DateTime)reader["DEPARTURE_TIME"],
                        landingTime = (DateTime)reader["LANDING_TIME"],
                        tickets = (int)reader["REMAINING_TICKETS"]

                    };
                    resultInfo.Add(flightInfo);
                }
                cmd.Connection.Close();
            }
            for (int i = 0; i < resultInfo.Count(); i++)
            {
                using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetCountriesByOriCode", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@originCountryCode", resultInfo[i].originalCountryCode));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {  
                        resultInfo[i].originFlightLocation = (string)reader["COUNTRY_NAME"];
                    }
                    cmd.Connection.Close();
                }

            }
            for (int i = 0; i < resultInfo.Count(); i++)
            {
                using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetCountriesByDestCode", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@destCountryCode", resultInfo[i].destCountryCode));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        resultInfo[i].destFlightLocation = (string)reader["COUNTRY_NAME"];
                    }
                    cmd.Connection.Close();
                }
            }
            return resultInfo; 
        }


        public List<CustomerInfoByAirlineName> GetFlightsByFlightNum(long flightNum)
        {
            List<CustomerInfoByAirlineName> returnList = new List<CustomerInfoByAirlineName>();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetFlightsByFlightNumFromDb", conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@flightNum", flightNum));
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                //ill show u, after this u can see the query inside the ssms
                //this is the reader im talking about..
                while (reader.Read() == true)
                {
                    CustomerInfoByAirlineName flightInfo = new CustomerInfoByAirlineName()
                    {
                        flightNum = flightNum,
                        originalCountryCode = (long)reader["ORIGIN_COUNTRY_CODE"],
                        destCountryCode = (long)reader["DESTINATION_COUNTRY_CODE"],
                        departureTime = (DateTime)reader["DEPARTURE_TIME"],
                        landingTime = (DateTime)reader["LANDING_TIME"],
                        tickets = (int)reader["REMAINING_TICKETS"]

                    };
                    returnList.Add(flightInfo);
                }
                cmd.Connection.Close();
            }
            for (int i = 0; i < returnList.Count(); i++)
            {
                using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetCountriesByOriCode", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@originCountryCode", returnList[i].originalCountryCode));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        returnList[i].originFlightLocation = (string)reader["COUNTRY_NAME"];
                    }
                    cmd.Connection.Close();
                }

            }
            for (int i = 0; i < returnList.Count(); i++)
            {
                using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetCountriesByDestCode", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@destCountryCode", returnList[i].destCountryCode));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        returnList[i].destFlightLocation = (string)reader["COUNTRY_NAME"];
                    }
                    cmd.Connection.Close();
                }
            }

            return returnList;
        }

        public List<CustomerInfoByAirlineName> GetFlightsByOriginCountryName(string originCountryName)
        {
            long countryCode = 0;
            List<CustomerInfoByAirlineName> resultInfo = new List<CustomerInfoByAirlineName>();
            using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCountryCodeByName", conn);
                cmd.Connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@countryName", originCountryName));
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                while (reader.Read() == true)
                {
                    countryCode = (long)reader["ID"];

                }
                cmd.Connection.Close();
            }
                using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetFlightInfoByOriCountryCode", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@countryCode", countryCode));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        CustomerInfoByAirlineName info = new CustomerInfoByAirlineName()
                        {
                            flightNum = (long)reader["ID"],
                            destCountryCode = (long)reader["DESTINATION_COUNTRY_CODE"],
                            departureTime = (DateTime)reader["DEPARTURE_TIME"],
                            landingTime = (DateTime)reader["LANDING_TIME"],
                            tickets = (int)reader["REMAINING_TICKETS"]
                        };
                        resultInfo.Add(info);
                    }
                    cmd.Connection.Close();
                }

            
            for (int i = 0; i < resultInfo.Count(); i++)
            {
                using (SqlConnection conn = new SqlConnection(FlightCenterConfig.connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetCountriesByDestCode", conn);
                    cmd.Connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@destCountryCode", resultInfo[i].destCountryCode));
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);
                    while (reader.Read() == true)
                    {
                        resultInfo[i].destFlightLocation = (string)reader["COUNTRY_NAME"];
                    }
                    cmd.Connection.Close();
                }
            }
            foreach (CustomerInfoByAirlineName info in resultInfo)
            {
                info.originFlightLocation = originCountryName;
            }

            return resultInfo;
        }
    }
}
