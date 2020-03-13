using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Pocos
{
    public class DeparturesPoco
    {
        public string flightName;
        public string originFlightLocation;
        public string destFlightLocation;
        public DateTime estimatedTime;
        public int tickets;
        public string status;
        public long destinationCountryCode;

        public DeparturesPoco()
        {

        }
        public DeparturesPoco(string flightName ,string originFlightLocation, string destFlightLocation,DateTime estimatedTime,int tickets , string status, long destinationCountryCode)        {
            this.flightName = flightName;
            this.originFlightLocation = originFlightLocation;
            this.destFlightLocation = destFlightLocation;
            this.estimatedTime = estimatedTime;
            this.tickets = tickets;
            this.status = status;
            this.destinationCountryCode = destinationCountryCode;
        }
    }
}
