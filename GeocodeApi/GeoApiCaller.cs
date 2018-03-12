using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AdressLocator.Entities;
using System.Collections.Generic;

namespace AdressLocator.GeocodeApi
{
    /// <summary>
    ///     An implementation of IGeoApiCaller to get the Longitude / Latitude Information for Adresses.
    ///     Creates a Webclient to get the required Information.
    /// </summary>
    internal class GeoApiCaller : IGeoApiCaller
    {
        /// <summary>
        ///     A client to call the location-webservice
        /// </summary>
        private HttpClient client;
        /// <summary>
        ///     The adress of the geocoding webservice
        /// </summary>
        private string apiCall;

        /// <summary>
        ///     The constructor of the class GeoApiCaller which creates the httpClient
        /// </summary>
        /// <param name="hostAdress">The adress of the server for the webservice call</param>
        /// <param name="apiCall">The adress of the geocoding webservice</param>
        internal GeoApiCaller(string hostAdress, string apiCall)
        {
            this.client = new HttpClient
            {
                BaseAddress = new Uri(hostAdress)
            };
            this.apiCall = apiCall;
        }

        /// <summary>
        ///     Converts an instance of Adress into a Json-Object
        /// </summary>
        /// <param name="adress">An Instance of adress</param>
        /// <returns>An adress converted into a Json-string</returns>
        private string SerializeAdress(Adress adress)
        {
            return JsonConvert.SerializeObject(adress);
        }

        /// <summary>
        ///     Converts a Json-string into an instance of Coordinate
        /// </summary>
        /// <param name="response">A Json-String with longitude / latitude information</param>
        /// <returns>A coordinate with the extracted information of the input</returns>
        private Coordinate DeserializeResponse(string response)
        {
            return JsonConvert.DeserializeObject<Coordinate>(response);
        }

        /// <summary>
        ///     Returns the Longitude / Latitude for the input adress via a webservice call
        /// </summary>
        /// <param name="adress">An instance of the Adress class with at least the stored attributes locality, zip, street, 
        ///     streetnumber (not mandatory) to call the api</param>
        /// <returns>A Task with input adress enriched with location information</returns>
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

        /// <summary>
        ///     Calls the GetLongitudeLatitude Method for every instance in the provided list and returns 
        ///     the entry list of adresses enriched with the attribute "Coordinate".
        /// </summary>
        /// <param name="adress">A list of adresses with at least the stored attributes locality, zip, street, 
        ///     streetnumber (not mandatory) to call the api</param>
        /// <returns>The input list of adresses enriched with location information</returns>
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
