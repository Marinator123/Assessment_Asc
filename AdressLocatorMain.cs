using System;
using System.Collections.Generic;
using AdressLocator.GeocodeApi;
using AdressLocator.FileIO;
using AdressLocator.Entities;

namespace AdressLocator
{
    /// <summary>
    /// Main-Class which does the following steps:
    ///     1. Converting of the provided input file into a list of adresses
    ///     2. Geocoding of the adresses with latitude / longitude information
    ///     3. Writing the obtained list to a Geojson file
    /// </summary>
    class AdressLocatorMain
    {
        /// <summary>
        ///     Converts the provided inputFile into an Adresslist, Geocodes the adresses and exports them to the provided outputFile
        /// </summary>
        /// <param name="inputFilePath">Relative or absolut Path to the input adress-file</param>
        /// <param name="inputFileDelimiters">Delimiters to separate the columns of a row in the input file</param>
        /// <param name="hostAdress">The Adress of the Webservice</param>
        /// <param name="apiCall">The apiCall of the webservice for the geocoding</param>
        /// <param name="outputFilePath">The path to the outputfile</param>
        private static void RunAdressLocator(string inputFilePath, char[] inputFileDelimiters, string hostAdress, string apiCall, 
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
            } catch (Exception ex)
            {
                Console.WriteLine("Export failed");
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            /// Path to the input-file;
            //string filePath = "./Data/Post_Adressdaten20170425.csv";
            string inputFilePath = "./Data/Adressdaten_Subset.csv";
            /// Use semicolons as delimiters in the input-file
            char[] inputDelimiters = new char[] { ';' };
            /// The adress of the webservice
            string hostAdress = "http://localhost:5000/";
            /// the api-call of the webservice
            string apiCall = "api/geo";
            /// the adress of the output-file
            string outputFilePath = @"C:\temp\export.json";
            /// Run the Adress locator
            RunAdressLocator(inputFilePath, inputDelimiters, hostAdress, apiCall, outputFilePath);
        }
    }
}
