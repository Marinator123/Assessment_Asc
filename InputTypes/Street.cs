namespace AdressLocator.InputTypes
{
    class Street : IInputType
    {
        private static int[] entryList = new int[] { 2, 4 };
        public string Onrp { get; }
        public string StreetName { get; }

        public Street(string[] values)
        {
            Onrp = values[entryList[0]];
            StreetName = values[entryList[1]];
        }

        public int[] GetEntryList()
        {
            return entryList;
        }
    }
}
