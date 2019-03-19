using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WeatherData weatherData;
        static async Task<string> StringDownload()
        {
            string responseBody = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    responseBody = await client.GetStringAsync("https://pogoda.onet.pl/prognoza-pogody/wroclaw-362450");
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine("error: " + e.Message);
                }

            }

            return responseBody;
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Download_Click(object sender, RoutedEventArgs e)
        {
            var resultTask = StringDownload();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(await resultTask);

            //Jedna z metod poruszania się po nodach (znacznikach) w html z użyciem biblioteki HtmlAgilityPack
            var weatherTemperature = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("weather-currently-temp-strict")).First().InnerText;

            //Druga metoda za pomocą ścieżki xPath również obsługiwanej przez HtmlAgilityPack
            var weatherState = htmlDocument.DocumentNode.SelectNodes("//li[@class='weather-currently-icon-description']").First().InnerText.Trim();
            var weatherTemperatureFelt = htmlDocument.DocumentNode.SelectSingleNode("//li[@class='weather-currently-details-item feelTemperature']/span").InnerText;
            var weatherPressure = htmlDocument.DocumentNode.SelectSingleNode("//li[@class='weather-currently-details-item pressure']/span").InnerText.Replace(" ", "");
            var weatherWind = htmlDocument.DocumentNode.SelectSingleNode("//li[@class='weather-currently-details-item wind']/span").InnerText.Replace(" ", "");
            //var weatherIcon = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='weather-currently-icon ico-33']");

            weatherData = new WeatherData(weatherTemperature, weatherTemperatureFelt, weatherPressure, weatherWind, weatherState);

            downloadedDataBox.Text = "Temperatura: " + weatherData.Temperature + "\n";
            downloadedDataBox.Text += "Temperatura odczuwalna: " + weatherData.TemperatureFelt + "\n";
            downloadedDataBox.Text += "Opis: " + weatherData.State + "\n";
            downloadedDataBox.Text += "Ciśnienie: " + weatherData.Pressure + " hPa\n";
            downloadedDataBox.Text += "Prędkość wiatru: " + weatherData.Wind + " km/h\n";
        }
    }
}
