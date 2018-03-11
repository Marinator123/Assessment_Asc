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
                geoJsonFile.Write(GetHeader());
            }
            catch (Exception)
            {
                Console.WriteLine("File Generation failed!");
            }
        }

        private string GetHeader()
        {
            return "{\n" +
                "\t\"type\": \"FeatureCollection\",\n" +
                "\t\"features\": [\n";
        }

        private string GetFooter()
        {
            return "\n\t]\n" +
                "}";
        }

        public void EndFeature()
        {
            geoJsonFile.Write(",\n");
        }

        public void CloseFile() {
            geoJsonFile.Write(GetFooter());
            geoJsonFile.Close();
        }


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
                "\t{{\n" +
                "\t\t\"type\": \"Feature\",\n" +
                "\t\t\"geometry\": {{\n" +
                "\t\t\t\"type\": \"Point\",\n" +
                "\t\t\t\"coordinates\": [{0},{1}]\n" +
                "\t\t}},\n" +
                "\t\t\"properties\": {{\n" +
                "\t\t\t\"street\": \"{2}\",\n" +
                "\t\t\t\"street number\": \"{3}\",\n" +
                "\t\t\t\"zip\": \"{4}\",\n" +
                "\t\t\t\"locality\": \"{5}\"\n" +
                "\t\t}}\n" +
                "\t}}"
                , adress.Coordinate.Longitude, adress.Coordinate.Latitude, adress.Street, adress.StreetNumber,
                    adress.Zip, adress.Locality);
        }
    }
}
