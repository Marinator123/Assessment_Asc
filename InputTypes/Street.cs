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
