

namespace AdressLocator
{
    /// <summary>
    /// Main-Class which does the following steps:
    ///     1. Converting of the provided input file into a list of adresses
    ///     2. Geocoding of the adresses with latitude / longitude information
    ///     3. Writing the obtained list to a Geojson file
    /// </summary>
    public class AdressLocatorMain
    {
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
            AdressLocatorRunner.RunAdressLocator(inputFilePath, inputDelimiters, hostAdress, apiCall, outputFilePath);
        }
    }
}
