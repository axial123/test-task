using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sofomo.Forecast.Integrations
{
   public class OpenMeteoApiHttpClient
    {
        private readonly HttpClient _httpClient;

        public OpenMeteoApiHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
