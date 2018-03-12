using System;
using System.Collections.Generic;
using AdressLocator.GeocodeApi;
using AdressLocator.FileIO;
using AdressLocator.Entities;

namespace AdressLocator
{
    /// <summary>
    /// Runner Class for the AdressLocatorProgramm
    /// </summary>
    internal static class AdressLocatorRunner
    {
        /// <summary>
        ///     Converts the provided inputFile into an Adresslist, Geocodes the adresses and exports them to the provided outputFile
        /// </summary>
        /// <param name="inputFilePath">Relative or absolut Path to the input adress-file</param>
        /// <param name="inputFileDelimiters">Delimiters to separate the columns of a row in the input file</param>
        /// <param name="hostAdress">The Adress of the Webservice</param>
        /// <param name="apiCall">The apiCall of the webservice for the geocoding</param>
        /// <param name="outputFilePath">The path to the outputfile</param>
        public static void RunAdressLocator(string inputFilePath, char[] inputFileDelimiters, string hostAdress, string apiCall,
            string outputFilePath)
        {
            try
            {
                /// The Webservice caller to transform adresses into geocoded adresses.
                GeoApiCaller caller = new GeoApiCaller(hostAdress, apiCall);
                /// The fileexporter, which exports the adress-list to a GeoJson to the provided filepath
                AdressToGeoJsonConverter geoJsonExporter = new AdressToGeoJsonConverter(outputFilePath);

                /// Extract all Adresses from the input File and store them in a list
                List<Adress> adresses = FileToAdressConverter.ExtractAdressesFromFile(inputFilePath, inputFileDelimiters);
                /// Geocode all the adresses and store them in a list
                List<Adress> geoCodedAdresses = caller.GetGeocodedAdresses(adresses);

                /// Write the geocoded Adresses to the export-file
                geoJsonExporter.OpenFile();
                geoJsonExporter.ExportAdressesToOutput(geoCodedAdresses);
                geoJsonExporter.CloseFile();

                Console.WriteLine("Export succesful");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Export failed");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
