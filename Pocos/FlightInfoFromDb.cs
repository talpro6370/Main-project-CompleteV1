using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Pocos
{
    public class FlightInfoFromDb
    {
        public long flightNum;
        public string originFlightLocation;
        public string destFlightLocation;
        public DateTime departureTime;
        public DateTime landingTime;
        public int tickets;
        public long originalCountryCode;

        public FlightInfoFromDb()
        {

        }

        public FlightInfoFromDb(long flightNum, string originFlightLocation, string destFlightLocation, DateTime departureTime, DateTime landingTime, int tickets,long originalCountryCode)
        {
            this.flightNum = flightNum;
            this.originFlightLocation = originFlightLocation;
            this.destFlightLocation = destFlightLocation;
            this.departureTime = departureTime;
            this.landingTime = landingTime;
            this.tickets = tickets;
            this.originalCountryCode = originalCountryCode;
        }
    }
}
