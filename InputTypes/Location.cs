namespace AdressLocator.InputTypes
{
    class Location : IInputType
    {
        private static int[] entryList = new int[] { 4, 7 };
        public string Plz { get; }
        public string Locality { get; }

        public Location(string[] values)
        {
            Plz = values[entryList[0]];
            Locality = values[entryList[1]];
        }

        public int[] GetEntryList()
        {
            return entryList;
        }
    }
}
