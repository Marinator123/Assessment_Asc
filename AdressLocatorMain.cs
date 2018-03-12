using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdressLocator.GeocodeApi;
using AdressLocator.FileIO;
using AdressLocator.Entities;
using System.Collections.Concurrent;

namespace AdressLocator
{
    class AdressLocatorMain
    {
        static void Main(string[] args)
        {
            //string filePath = "./Data/Post_Adressdaten20170425.csv";
            string filePath = "./Data/Adressdaten_Subset.csv";
            char[] delimiters = new char[]{';'};
            GeoApiCaller caller = new GeoApiCaller("http://localhost:5000/", "api/geo");
            AdressToGeoJsonConverter geoJsonExporter = new AdressToGeoJsonConverter(@"C:\temp\export.json");

            List<Adress> adresses = FileToAdressConverter.ExtractAdressesFromFile(filePath, delimiters);
            List<Adress> geoLocatedAdresses = caller.GetGeoLocatedAdresses(adresses);

            geoJsonExporter.OpenFile();
            geoJsonExporter.ExportAdressesToOutput(geoLocatedAdresses);
            geoJsonExporter.CloseFile();

            Console.WriteLine("Export succesful");
        }
    }
}
