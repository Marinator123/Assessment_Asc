using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdressLocator.GeocodeApi;
using AdressLocator.FileIO;
using AdressLocator.Entities;

namespace AdressLocator
{
    class Program
    {
        static void Main(string[] args)
        {
            //string filePath = "./Data/Post_Adressdaten20170425.csv";
            string filePath = "./Data/Adressdaten_Subset.csv";
            char[] delimiters = new char[] {';'};

            FileToAdressConverter fileReader = new FileToAdressConverter();
            fileReader.ConvertFileToLists(filePath, delimiters);
            List<Adress> adresses = fileReader.GetAdresses();

            GeoApiCaller caller = new GeoApiCaller("http://localhost:5000/");
            AdressToGeoJsonConverter geoJsonExporter = new AdressToGeoJsonConverter(@"C:\temp\export.json");

            Adress first = adresses.First();
            foreach(Adress adress in adresses)
            {
                Adress geoLocatedAdress = caller.GetLongitudeLatitude(adress).Result;
                if (!adress.Equals(first))
                {
                    geoJsonExporter.EndFeature();
                }
                geoJsonExporter.WriteAdressToFile(geoLocatedAdress);
            }
            geoJsonExporter.CloseFile();
        }
    }
}
