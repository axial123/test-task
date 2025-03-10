using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofomo.Forecast
{
   public class ForecastDto
    {
        public double Temperature { get; set; }
        public DateTime Time { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public ForecastDto(double temperature, DateTime time, double latitude, double longitude)
        {
            Temperature = temperature;
            Time = time;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
