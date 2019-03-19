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
            Temperature = int.Parse(Regex.Replace(setTemperature, "[^-0-9]", ""));
            TemperatureFelt = int.Parse(Regex.Replace(setTemperatureFelt, "[^-0-9]", ""));
            Pressure = int.Parse(Regex.Replace(setPressure, "[^0-9]", ""));
            Wind = int.Parse(Regex.Replace(setWind, "[^0-9]", ""));
            State = setState;
        }

        public int Temperature { get; }
        public int TemperatureFelt { get; }
        public int Pressure { get; }
        public int Wind { get; }
        public string State { get; }
    }
}
