using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AdressLocator.Entities;

namespace AdressLocator.FileIO
{
    class AdressToGeoJsonConverter
    {

        StreamWriter geoJsonFile;
        public AdressToGeoJsonConverter(string filePath)
        {   try
            {
                geoJsonFile = new StreamWriter(filePath);
            }
            catch (Exception)
            {
                Console.WriteLine("File Generation failed!");
            }
        }

        public void CloseFile() => geoJsonFile.Close();


        public void WriteAdressToFile(Adress adress)
        {
            string geoJson = GeoJsonPoint.getGeoJson(adress);
            geoJsonFile.Write(geoJson);
        }
    }


    struct GeoJsonPoint
    {
        public static string getGeoJson(Adress adress)
        {
            return String.Format(
                "{{\n" +
                "\t\"type\": \"Feature\",\n" +
                "\t\"geometry\": {{\n" +
                "\t\t\"type\": \"Point\",\n" +
                "\t\t\"coordinates\": [{0},{1}]\n" +
                "\t}},\n" +
                "\t\"properties\": {{\n" +
                "\t\t\"street\": \"{2}\",\n" +
                "\t\t\"street number\": \"{3}\",\n" +
                "\t\t\"zip\": \"{4}\",\n" +
                "\t\t\"locality\": \"{5}\"\n" +
                "\t}}\n" +
                "}}"
                , adress.Coordinate.Longitude, adress.Coordinate.Latitude, adress.Street, adress.StreetNumber,
                    adress.Zip, adress.Locality);
        }
    }
}
