using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProject.Pocos
{
    public class QueryParams
    {
        private long flightNumber;
        private string airlineName;
        private string destCountry;
        private string originCountry;
        private string flightType;

        public long FlightNumber
        {
            get
            {
                return flightNumber;
            } set
            {
                this.flightNumber = value;
            }
        }
        public string AirlineName
        {
            get
            {
                return airlineName;
            }
            set
            {
                this.airlineName = value;
            }
        }
        public string DestCountry
        {
            get
            {
                return destCountry;
            }
            set
            {
                this.destCountry = value;
            }
        }
        public string OriginCountry
        {
            get
            {
                return originCountry;
            }
            set
            {
                this.originCountry = value;
            }
        }
        public QueryParams()
        {

        }
        public QueryParams(long flightNumber, string airlineName, string destCountry,string originCountry,string flightType)
        {
            this.flightNumber = flightNumber;
            this.airlineName = airlineName;
            this.destCountry = destCountry;
            this.originCountry = originCountry;
            this.flightType = flightType;
        }
        public override string ToString()
        {
            return $"Flight Number: {flightNumber}, Airline Name: {airlineName}," + $"Destinatio Country: {destCountry}, Original Country: {originCountry}";
                
        }
    }
    

}
