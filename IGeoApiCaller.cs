using System.Threading.Tasks;

namespace AdressLocator
{
    interface IGeoApiCaller
    {
        Task<Adress> GetLongitudeLatitude(Adress adress);
    }
}
