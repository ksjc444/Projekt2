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

        static async Task<string> StringDownload()
        {
            string responseBody = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    responseBody = await client.GetStringAsync("https://www.twojapogoda.pl/prognoza-polska/dolnoslaskie-wroclaw/");
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
            downloadedDataBox.Text = await resultTask;
        }
    }
}
