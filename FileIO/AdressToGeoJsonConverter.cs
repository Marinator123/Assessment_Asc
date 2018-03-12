using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using AdressLocator.Entities;

namespace AdressLocator.FileIO
{
    /// <summary>
    ///     This class includes methods to convert a provided list of adresses into a geoJson-File
    /// </summary>
    internal class AdressToGeoJsonConverter
    {
        /// <summary>
        ///     The relative or absolute path to the export File
        /// </summary>
        private string filePath;
        /// <summary>
        ///     The FileWriter
        /// </summary>
        private StreamWriter geoJsonFile;

        /// <summary>
        ///     The constructor of the class 
        /// </summary>
        /// <param name="filePath">The path to the export File</param>
        internal AdressToGeoJsonConverter(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        ///     Opens the StreamWriter and writes the Header. Throws an exception, if
        ///     the file couldn't be opened.
        /// </summary>
        internal void OpenFile()
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

        /// <summary>
        ///     Writes a List of Adresses to the defined output file.
        /// </summary>
        /// <param name="geoCodedAdresses">A List of geocoded instances of the class Adress</param>
        internal void ExportAdressesToOutput(List<Adress> geoCodedAdresses)
        {
            // The first entry in the Adress-List.
            Adress first = geoCodedAdresses.First();
            foreach (Adress geoCodedAdress in geoCodedAdresses)
            {
                // Write the feature separator to the file if it's not the first feature
                if (!geoCodedAdress.Equals(first))
                {
                    geoJsonFile.Write(GeoJsonFormatter.GetFeatureEnd());
                }
                this.WriteAdressToFile(geoCodedAdress);
            }
        }

        /// <summary>
        ///     Writes the footer to the geoJson file and closes it.
        /// </summary>
        internal void CloseFile() {
            geoJsonFile.Write(GeoJsonFormatter.GetFooter());
            geoJsonFile.Close();
        }

        /// <summary>
        ///     Writes a geolocatedAdress to the export file as a geoJson-Point.
        /// </summary>
        /// <param name="adress"></param>
        private void WriteAdressToFile(Adress adress)
        {
            string geoJsonPoint = GeoJsonFormatter.GetGeoJsonAdress(adress);
            geoJsonFile.Write(geoJsonPoint);
        }
    }

    /// <summary>
    ///     Helper Class to print an Adress-List to a geojson File.
    /// </summary>
    internal static class GeoJsonFormatter
    {
        /// <summary>
        ///     Returns the header of the geoJson-File
        /// </summary>
        /// <returns>The header of the geoJson-File</returns>
        internal static string GetHeader()
        {
            return "{\n" +
                "\t\"type\": \"FeatureCollection\",\n" +
                "\t\"features\": [\n";
        }

        /// <summary>
        ///     Returns the footer of the GeoJson-File
        /// </summary>
        /// <returns>The footer of the GeoJson-File</returns>
        internal static string GetFooter()
        {
            return "\n\t]\n" +
                "}";
        }

        /// <summary>
        ///     Returns the separator of two features in a geoJson-File
        /// </summary>
        /// <returns></returns>
        internal static string GetFeatureEnd()
        {
            return ",\n";
        }

        /// <summary>
        ///     Converts a provided adress to a geoJson-Feature
        /// </summary>
        /// <param name="adress">An instance of the class adress with location information.</param>
        /// <returns>A geoJson point feature representing an adress</returns>
        internal static string GetGeoJsonAdress(Adress adress)
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
