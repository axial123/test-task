namespace Sofomo.Forecast.Integrations;

internal record OpenMeteoDto(double Longitude, double Latitude, Temperature Current);

internal record Temperature(DateTime Time, double Temperature_2m);
