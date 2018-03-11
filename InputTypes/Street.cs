using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressLocator.InputTypes
{
    class Street : IEntryHandler
    {
        private static int[] entryList = new int[] { 2, 4 };
        public string Onrp { get; set; }
        public string StreetName { get; set; }

        public Street(string[] values)
        {
            Onrp = values[entryList[0]];
            StreetName = values[entryList[1]];
        }
    }
}
