using System.Collections.Generic;
using System.Threading.Tasks;
using AdressLocator.Entities;

namespace AdressLocator.GeocodeApi
{
    interface IGeoApiCaller
    {
        Task<Adress> GetLongitudeLatitude(Adress adress);
        List<Adress> GetGeoLocatedAdresses(List<Adress> adress);
    }
}
