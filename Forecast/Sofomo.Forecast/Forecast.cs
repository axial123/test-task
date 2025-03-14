﻿namespace Sofomo.Forecast;

internal class Forecast
{
    public int Id { get; init; }
    public double Temperature { get; set; }
    public DateTime Time { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Forecast(double temperature, DateTime time, double latitude, double longitude)
    {
        Temperature = temperature;
        Time = time;
        Latitude = latitude;
        Longitude = longitude;
    }
    private Forecast() { }
}
