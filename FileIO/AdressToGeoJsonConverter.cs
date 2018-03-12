using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using AdressLocator.Entities;

namespace AdressLocator.FileIO
{
    class AdressToGeoJsonConverter
    {
        string filePath;
        StreamWriter geoJsonFile;
        public AdressToGeoJsonConverter(string filePath)
        {
            this.filePath = filePath;
        }

        public void OpenFile()
        {
            try
            {
                geoJsonFile = new StreamWriter(filePath);
                geoJsonFile.Write(GeoJsonFormatter.GetHeader());
            }
            catch (Exception)
            {
                Console.WriteLine("Opening File failed!");
            }
        }

        public void ExportAdressesToOutput(List<Adress> geoLocatedAdresses)
        {
            Adress first = geoLocatedAdresses.First();
            foreach (Adress geoLocatedAdress in geoLocatedAdresses)
            {
                if (!geoLocatedAdress.Equals(first))
                {
                    geoJsonFile.Write(GeoJsonFormatter.GetFeatureEnd());
                }
                this.WriteAdressToFile(geoLocatedAdress);
            }
        }

        public void CloseFile() {
            geoJsonFile.Write(GeoJsonFormatter.GetFooter());
            geoJsonFile.Close();
        }

        private void WriteAdressToFile(Adress adress)
        {
            string geoJsonPoint = GeoJsonFormatter.GetGeoJsonAdress(adress);
            geoJsonFile.Write(geoJsonPoint);
        }
    }

    static class GeoJsonFormatter
    {
        public static string GetHeader()
        {
            return "{\n" +
                "\t\"type\": \"FeatureCollection\",\n" +
                "\t\"features\": [\n";
        }

        public static string GetFooter()
        {
            return "\n\t]\n" +
                "}";
        }

        public static string GetFeatureEnd()
        {
            return ",\n";
        }

        public static string GetGeoJsonAdress(Adress adress)
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
