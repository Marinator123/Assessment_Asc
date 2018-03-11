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
            /*
            Adress adress = new Adress
            {
                Locality = "Bla",
                Zip = "1234",
                Street = "blabla",
                StreetNumber = "roflrofl"
            };
            GeoApiCaller caller = new GeoApiCaller("http://localhost:5000/");

            Adress bla = caller.GetLongitudeLatitude(adress).Result;
            Console.WriteLine(bla.Coordinate.Latitude);
            Console.WriteLine(bla.Street);*/
            string filePath = "./Data/Adressdaten_Subset.csv";
            char[] delimiters = new char[] {';'};
            FileReader.ReadFile(filePath, delimiters);

            Console.ReadLine();
        }
    }
}
