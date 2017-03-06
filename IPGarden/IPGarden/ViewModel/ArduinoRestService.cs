using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using IPGarden.Model;

namespace IPGarden.ViewModel
{
    public class ArduinoRestService
    {

        HttpClient client;
        static Uri baseUri = new Uri("http://192.168.0.101/");
        RelayPanel relayPanel;
        SensorPanel sensorPanel;

        public ArduinoRestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }


        public async Task<int> ActivateSwitchAsync(string stationID)
        {
            Uri uri = new Uri(baseUri, String.Concat("relay?params=",stationID)); ;

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    relayPanel = JsonConvert.DeserializeObject<RelayPanel>(content);
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            return relayPanel.return_value;
        }

        public async Task<int> ReadTemperatureAsync()
        {
            try
            {
                var response = await client.GetAsync(baseUri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    sensorPanel = JsonConvert.DeserializeObject<SensorPanel>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return sensorPanel.variables.temperature;
        }

        public async Task<int> ReadHumidityAsync()
        {
            try
            {
                var response = await client.GetAsync(baseUri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    sensorPanel = JsonConvert.DeserializeObject<SensorPanel>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return sensorPanel.variables.humidity;
        }
    }
}
