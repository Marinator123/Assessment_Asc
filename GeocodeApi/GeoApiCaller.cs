using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AdressLocator.Entities;

namespace AdressLocator.GeocodeApi
{
    public class GeoApiCaller : IGeoApiCaller
    {
        private HttpClient client;

        public GeoApiCaller(string hostAdress)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(hostAdress)
            };    
        }

        private string SerializeAdress(Adress adress)
        {
            return JsonConvert.SerializeObject(adress);
        }

        private Coordinate DeserializeResponse(string response)
        {
            return JsonConvert.DeserializeObject<Coordinate>(response);
        }

        public async Task<Adress> GetLongitudeLatitude(Adress adress)
        {
            string requestBody = SerializeAdress(adress);
            StringContent stringContent = new StringContent(requestBody, UnicodeEncoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("api/geo", stringContent);
            
            if (response.IsSuccessStatusCode)
            {
                Coordinate coords = DeserializeResponse(response.Content.ReadAsStringAsync().Result);
                adress.Coordinate = coords;
            }
            
            return adress;
        }
    }


}
