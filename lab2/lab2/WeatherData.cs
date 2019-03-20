using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace lab2
{
    public class WeatherData
    {
        public WeatherData(string setTemperature, string setTemperatureFelt, string setPressure, string setWind, string setHumidity, string setRain, string setClouds, string setState, string setIconLink )
        {
            Temperature = int.Parse(Regex.Replace(setTemperature, "[^-0-9]", ""));
            TemperatureFelt = int.Parse(Regex.Replace(setTemperatureFelt, "[^-0-9]", ""));
            Pressure = int.Parse(Regex.Replace(setPressure, "[^0-9]", ""));
            Wind = int.Parse(Regex.Replace(setWind, "[^0-9]", ""));
            Humidity = int.Parse(Regex.Replace(setHumidity, "[^0-9]", ""));
            Rain = int.Parse(Regex.Replace(setRain, "[^0-9]", ""));
            Clouds = int.Parse(Regex.Replace(setClouds, "[^0-9]", ""));

            State = setState;
            if (setIconLink.StartsWith("http:") || setIconLink.StartsWith("https:"))
                IconLink = setIconLink;
            else
                IconLink = "https:" + setIconLink;
            //BackgroundLink = setBackgroundLink;
        }

        public int Temperature { get; }
        public int TemperatureFelt { get; }
        public int Pressure { get; }
        public int Wind { get; }
        public int Humidity { get; }
        public int Rain { get; }
        public int Clouds { get; }
        public string State { get; }
        public string IconLink { get; }
        //public string BackgroundLink { get; }
    }
}
