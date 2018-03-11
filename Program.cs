using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressLocator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            Adress adress = new Adress
            {
                locality = "Bla",
                zip = "1234",
                street = "blabla",
                streetNumber = "roflrofl"
            };
            GeoApiCaller caller = new GeoApiCaller("http://localhost:5000/");

            Console.WriteLine(caller.GetLongitudeLatitude(adress).ToString());

            Console.ReadLine();
        }
    }
}
