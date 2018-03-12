namespace AdressLocator.InputTypes
{
    class Location
    {
        private readonly static int[] entryList = new int[] { 4, 7 };
        public string Plz { get; }
        public string Locality { get; }

        public Location(string[] values)
        {
            Plz = values[entryList[0]];
            Locality = values[entryList[1]];
        }
    }
}
