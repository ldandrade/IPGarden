using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IPGarden.ViewModel
{
    public class ArduinoRestService
    {

        HttpClient client;
        static Uri baseUri = new Uri("http://192.168.0.101/");
        RelayPanel relayPanel;
        TempSensor tempSensor;
        HumSensor humSensor;

        internal RelayPanel RelayPanel
        {
            get
            {
                return relayPanel;
            }

            set
            {
                relayPanel = value;
            }
        }

        internal TempSensor TempSensor
        {
            get
            {
                return tempSensor;
            }

            set
            {
                tempSensor = value;
            }
        }

        internal HumSensor HumSensor
        {
            get
            {
                return humSensor;
            }

            set
            {
                humSensor = value;
            }
        }

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
                    RelayPanel = JsonConvert.DeserializeObject<RelayPanel>(content);
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
            return RelayPanel.Return_value;
        }

        public async Task<int> ReadTemperatureAsync()
        {
            Uri uri = new Uri(baseUri, "temperature");

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    tempSensor = JsonConvert.DeserializeObject<TempSensor>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return tempSensor.Temperature;
        }

        public async Task<int> ReadHumidityAsync()
        {
            Uri uri = new Uri(baseUri, "humidity");

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    humSensor = JsonConvert.DeserializeObject<HumSensor>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            return humSensor.Humidity;
        }
    }
}
