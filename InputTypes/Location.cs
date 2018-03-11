namespace AdressLocator.InputTypes
{
    class Location
    {
        private static int[] entryList = new int[] { 4, 7 };
        public string Plz { get; set; }
        public string Locality { get; set; }

        public Location(string[] values)
        {
            Plz = values[entryList[0]];
            Locality = values[entryList[1]];
        }
    }
}
