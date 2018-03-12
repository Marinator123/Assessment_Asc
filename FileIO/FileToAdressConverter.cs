using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AdressLocator.InputTypes;
using AdressLocator.Entities;

namespace AdressLocator.FileIO
{
    /// <summary>
    ///     Class to read in a file containing the "Post"-adresses of Switzerland corresponding to
    ///     "Strassenverzeichnis mit Sortierdaten und Strassenverzeichnis mit Gemeindenummern" and to
    ///     store this file in a List of Adresses.
    /// </summary>
    internal static class FileToAdressConverter {

        /// <summary>
        ///     Dictionary of all Postcodes found in the input file with key: Onrp (Ordnungsnummer Post) and element: location
        /// </summary>
        private static Dictionary<string, Location> plzList = new Dictionary<string, Location>();
        /// <summary>
        ///     Dictionary of all streets found in the input file with key: streetid and element: Street
        /// </summary>
        private static Dictionary<string, Street> streetList = new Dictionary<string, Street>();
        /// <summary>
        ///     List of all buildings found in the input file.
        /// </summary>
        private static List<Building> buildings = new List<Building>();

        /// <summary>
        ///     A runner method for the class FileToAdressConverter which needs an input file and returns all 
        ///     Adresses in a list found in the input file
        /// </summary>
        /// <param name="filePath">Path to the input file</param>
        /// <param name="lineDelimiters">The delimiters for the input file</param>
        /// <returns></returns>
        internal static List<Adress> ExtractAdressesFromFile(string filePath, char[] lineDelimiters)
        {
            ConvertFileToLists(filePath, lineDelimiters);
            return GetAdresses();
        }

        /// <summary>
        ///     Writes each required object from the input file to the corresponding list
        /// </summary>
        /// <param name="filePath">Path to the input file</param>
        /// <param name="lineDelimiters">The delimiters for the input file</param>
        private static void ConvertFileToLists(string filePath, char[] lineDelimiters)
        {
            try
            {
                /// The input file
                string csvData = File.ReadAllText(filePath, Encoding.Default);
                /// All lines from the input file in an array
                string[] lines = csvData.Split('\n');
                foreach (string row in lines)
                {
                    /// All columns of the input row
                    string[] columns = row.Split(lineDelimiters);
                    /// The object code, which specifies the type of the object in the current row
                    string recArt = columns[0];
                    switch(recArt)
                    {
                        case "01":
                            plzList.Add(columns[1], new Location(columns));
                            break;
                        case "04":
                            streetList.Add(columns[1], new Street(columns));
                            break;
                        case "06":
                            buildings.Add(new Building(columns));
                            break;
                        default:
                            break;
                    }
                }
            } catch (FileNotFoundException)
            {
                Console.WriteLine("Ungültiger Dateiname: {0}", filePath);
            }
        }

        /// <summary>
        ///     Computes Adresses for all provided lists from the "ConvertFileToLists"-Method
        /// </summary>
        /// <returns>A list of all adresses from the provided input file</returns>
        private static List<Adress> GetAdresses()
        {
            List<Adress> adressList = new List<Adress>();
            /// For every building find every corresponding street and the corresponding-location and
            /// generate a new Adress object
            foreach (Building building in buildings)
            {
                string streetId = building.StreetId;
                streetList.TryGetValue(streetId, out Street correspondingStreet);

                if (correspondingStreet != null)
                {
                    string onrp = correspondingStreet.Onrp;
                    plzList.TryGetValue(onrp, out Location correspondingLocation);

                    if (correspondingLocation != null)
                    {
                        Adress adress = new Adress
                        {
                            Locality = correspondingLocation.Locality,
                            Zip = correspondingLocation.Plz,
                            Street = correspondingStreet.StreetName,
                            StreetNumber = building.StreetNumber ?? ""
                        };
                        adressList.Add(adress);
                    }
                }
            }
            return adressList;
        }
    }
}
