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
        public WeatherData(string setTemperature, string setTemperatureFelt, string setPressure, string setWind, string setState)
        {
            temperature = int.Parse(Regex.Replace(setTemperature, "[^0-9]", ""));
            temperatureFelt = int.Parse(Regex.Replace(setTemperatureFelt, "[^0-9]", ""));
            pressure = int.Parse(Regex.Replace(setPressure, "[^0-9]", ""));
            wind = int.Parse(Regex.Replace(setWind, "[^0-9]", ""));
            state = setState;
        }

        int temperature;
        int temperatureFelt;
        int pressure;
        int wind;
        string state;
    }
}
