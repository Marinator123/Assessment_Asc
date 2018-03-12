using System.Collections.Generic;
using System.Threading.Tasks;
using AdressLocator.Entities;

namespace AdressLocator.GeocodeApi
{
    /// <summary>
    ///     An Interface for the GeoApiCaller to extract Location-informations of an adress.
    /// </summary>
    interface IGeoApiCaller
    {
        /// <summary>
        ///     Returns a Task with the Longitude / Latitude information for a single adress
        /// </summary>
        /// <param name="adress">An instance of the Adress class with at least the stored attributes locality, zip, street, 
        ///     streetnumber (not mandatory) to call the api</param>
        /// <returns>A Task with input adress enriched with location information</returns>
        Task<Adress> GetLongitudeLatitude(Adress adress);

        /// <summary>
        ///     Calls the GetLongitudeLatitude Method for every instance in the provided list and returns 
        ///     the entry list of adresses enriched with the attribute "Coordinate".
        /// </summary>
        /// <param name="adress">A list of adresses with at least the stored attributes locality, zip, street, 
        ///     streetnumber (not mandatory) to call the api</param>
        /// <returns>The input list of adresses enriched with location information</returns>
        List<Adress> GetGeocodedAdresses(List<Adress> adress);
    }
}
