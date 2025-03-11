using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofomo.Forecast.Integrations
{
   internal class OpenMeteoDto
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public Temperature Current { get; set; }
    }

    internal class Temperature
    {
        public DateTime Time { get; set; }
        public double Temperature_2m { get; set; }
    }
}
