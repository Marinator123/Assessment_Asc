using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdressLocator
{
    public class GeoApiCaller
    {
        HttpClient client;

        public GeoApiCaller(string baseAdress) {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseAdress);
            client.DefaultRequestHeaders.Accept.Clear();
        }


        private string serializeAdress(Adress adress)
        {
            return String.Format("{{" +
                "\"Locality\":\"{0}\"," +
                "\"Zip\":\"{1}\"," +
                "\"Street\":\"{2}\"," +
                "\"StreetNumber\":\"{3}\"" +
                "}}", adress.locality, adress.zip, adress.street, adress.streetNumber);
        }

        public async Task<string> GetLongitudeLatitude(Adress adress)
        {
            string requestBody = serializeAdress(adress);
            var stringContent = new StringContent(requestBody, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/geo", stringContent);
            string answer = "";
            if (response.IsSuccessStatusCode)
            {
                answer = await response.Content.ReadAsStringAsync();
            }
            return answer;
        }
    }


}
