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
        RelayItem relayItem;

        internal RelayItem RelayItem
        {
            get
            {
                return relayItem;
            }

            set
            {
                relayItem = value;
            }
        }

        public ArduinoRestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }


        public async Task<bool> ActivateSwitchAsync(string stationID)
        {
            Uri uri = new Uri(baseUri, String.Concat("relay?params=",stationID)); ;

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    RelayItem = JsonConvert.DeserializeObject<RelayItem>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
            if (RelayItem.Return_value==0)
                return false;
            else
                return true;
        }

        /**Task<int> ReadTemperatureAsync()
        {

        }

        Task<int> ReadHumidityAsync()
        {

        }**/
    }
}
