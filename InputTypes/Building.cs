using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressLocator.InputTypes
{
    class Building : IEntryHandler
    {
        
        static private int[] entryList = new int[]{ 2, 3 };
        public string Streetid { get; set; }
        public string Hnr { get; set; }

        public Building(string[] values)
        {
            Streetid = values[entryList[0]];
            Hnr = values[entryList[1]];
        }

    }
}
