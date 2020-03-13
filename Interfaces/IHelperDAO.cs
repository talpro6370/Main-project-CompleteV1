using MainProject.DAO;
using MainProject.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.InterFaces
{
    public interface IHelperDAO
    {
        List<DeparturesPoco> DeparturesDetails();
        List<ArrivalsPoco> ArrivalsDetails();
        List<FlightInfoFromDb> GetFlightsByDesCountryNameFromDb(string countryName);
        List<CustomerInfoByAirlineName> GetFlightsByAirlineName(string airlineName);
        List<CustomerInfoByAirlineName> GetFlightsByOriginCountryName(string originCountryName);
        List<CustomerInfoByAirlineName> GetFlightsByFlightNum(long flightNum);
    }
}
