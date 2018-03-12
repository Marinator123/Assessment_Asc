namespace AdressLocator.InputTypes
{
    class Building 
    {
        static readonly private int[] entryList = new int[]{ 2, 3 };
        public string StreetId { get; }
        public string Hnr { get; }

        public Building(string[] values)
        {
            StreetId = values[entryList[0]];
            Hnr = values[entryList[1]];
        }
    }
}
