using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AdressLocator.Entities;
using System.Collections.Generic;

namespace AdressLocator.GeocodeApi
{
    public class GeoApiCaller : IGeoApiCaller
    {
        private HttpClient client;
        private string apiCall;

        public GeoApiCaller(string hostAdress, string apiCall)
        {
            this.client = new HttpClient
            {
                BaseAddress = new Uri(hostAdress)
            };
            this.apiCall = apiCall;
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
            HttpResponseMessage response = await client.PostAsync(this.apiCall, stringContent);
            
            if (response.IsSuccessStatusCode)
            {
                Coordinate coords = DeserializeResponse(response.Content.ReadAsStringAsync().Result);
                adress.Coordinate = coords;
            }
            
            return adress;
        }

        public List<Adress> GetGeocodedAdresses(List<Adress> adresses)
        {
            List<Adress> geoLocatedAdresses = new List<Adress>();
            foreach (Adress adress in adresses)
            {
                Adress geoLocatedAdress = this.GetLongitudeLatitude(adress).Result;
                geoLocatedAdresses.Add(geoLocatedAdress);
            }
            return geoLocatedAdresses;
        }
    }
}
