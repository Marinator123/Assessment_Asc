using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressLocator.InputTypes
{
    class Location
    {
        private static int[] entryList = new int[] { 4, 7 };
        string Plz { get; set; }
        string Locality { get; set; }

        public Location(string[] values)
        {
            Plz = values[entryList[0]];
            Locality = values[entryList[1]];
        }
    }
}
