using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using AdressLocator.InputTypes;
using AdressLocator.Entities;

namespace AdressLocator.FileIO
{
    public static class FileToAdressConverter {

        private static Dictionary<string, Location> plzList = new Dictionary<string, Location>();
        private static Dictionary<string, Street> streetList = new Dictionary<string, Street>();
        private static List<Building> buildings = new List<Building>();

        public static List<Adress> ExtractAdressesFromFile(string filePath, char[] lineDelimiters)
        {
            ConvertFileToLists(filePath, lineDelimiters);
            return GetAdresses();
        }

        private static void ConvertFileToLists(string filePath, char[] lineDelimiters)
        {
            try
            {
                string csvData = File.ReadAllText(filePath, Encoding.Default);
                string[] lines = csvData.Split('\n');
                foreach (string row in lines)
                {
                    string[] words = row.Split(lineDelimiters);
                    string recArt = words[0];
                    switch(recArt)
                    {
                        case "01":
                            plzList.Add(words[1], new Location(words));
                            break;
                        case "04":
                            streetList.Add(words[1], new Street(words));
                            break;
                        case "06":
                            buildings.Add(new Building(words));
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

        private static List<Adress> GetAdresses()
        {
            List<Adress> adressList = new List<Adress>();

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
                            StreetNumber = building.Hnr ?? ""
                        };
                        adressList.Add(adress);
                    }
                }

            }
            return adressList;
        }
    }
}
