using MainProject.DAO;
using System.Collections.Generic;

namespace MainProject
{
    public interface IAirlineDAO :IBasicDB<AirlineCompany>
    {
        AirlineCompany GetAirlineByUserame(string name);
        List<AirlineCompany> GetAllAirlinesByCountry(int countryId);
        long GetAirlineCompanyId(string airlineUserName);
        void ChangePassword(string userName, string password);
        long GetRandomCountryId();
        long GetRandomAirlineId();
        string GetAirlineNameByID(int id);
        long GetFlightID(string flightName);
        long GetRandomFlightID();
    }
}