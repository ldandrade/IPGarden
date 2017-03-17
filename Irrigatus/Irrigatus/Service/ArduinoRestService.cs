using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Irrigatus.Model;

namespace Irrigatus.Service
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


        public async Task<bool> ActivateSwitchAsync(string stationID)
        {
            Uri uri = new Uri(baseUri, String.Concat("relayctrl?params=",stationID)); ;

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    relayPanel = JsonConvert.DeserializeObject<RelayPanel>(content);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            if (relayPanel.return_value == 0)
                return false;
            else
                return true;
        }

        public async Task<bool> GetSwitchStateAsync(string stationID)
        {
            Uri uri = new Uri(baseUri, String.Concat("relaystate?params=", stationID)); ;

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    relayPanel = JsonConvert.DeserializeObject<RelayPanel>(content);
                }
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            if (relayPanel.return_value == 0)
                return false;
            else
                return true;
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
            catch (InvalidOperationException ex)
            {
                throw ex;
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
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
            return sensorPanel.variables.humidity;
        }
    }
}
