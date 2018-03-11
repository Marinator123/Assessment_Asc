using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace AdressLocator
{
    public class FileReader {
    
        /*
        string path;

        public FileReader(string path) {
            this.path = path;
        }*/

        public static void ReadFile(string filePath, char[] lineDelimiters)
        {
            try {
                string csvData = File.ReadAllText(filePath);
                foreach (string row in csvData.Split('\n'))
                {
                    Console.WriteLine(row);
                    String[] words = row.Split(lineDelimiters);
                    Console.WriteLine(words[0]);
                }

                }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ungültiger Dateiname: {0}", filePath);
            }
        }

    }
}
