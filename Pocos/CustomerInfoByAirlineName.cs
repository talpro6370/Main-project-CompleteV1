using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Pocos
{
    public class CustomerInfoByAirlineName
    {
        public long flightNum;
        public string originFlightLocation;
        public string destFlightLocation;
        public DateTime departureTime;
        public DateTime landingTime;
        public int tickets;
        public long originalCountryCode;
        public long destCountryCode;

        public CustomerInfoByAirlineName()
        {

        }

        public CustomerInfoByAirlineName(long flightNum, string originFlightLocation, string destFlightLocation, DateTime departureTime, DateTime landingTime, int tickets, long originalCountryCode,long destCountryCode)
        {
            this.flightNum = flightNum;
            this.originFlightLocation = originFlightLocation;
            this.destFlightLocation = destFlightLocation;
            this.departureTime = departureTime;
            this.landingTime = landingTime;
            this.tickets = tickets;
            this.originalCountryCode = originalCountryCode;
            this.destCountryCode = destCountryCode;
        }
    }
}
