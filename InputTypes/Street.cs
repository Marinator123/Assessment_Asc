namespace AdressLocator.InputTypes
{
    /// <summary>
    /// Class to describe Street Entities extracted from the input File
    /// </summary>
    class Street
    {
        /// <summary>
        /// The Columns of a street-row, which need to be described from a Street-Instance
        /// </summary>
        private readonly static int[] entryList = new int[] { 2, 4 };
        /// <summary>
        /// Foreign-Key to Locations (Ordnungsnummer Post)
        /// </summary>
        public string Onrp { get; }
        /// <summary>
        /// The name of the Street
        /// </summary>
        public string StreetName { get; }

        /// <summary>
        /// Constructor of the Class Street which extracts all required attributes;
        /// </summary>
        /// <param name="values">An array of strings with all the Columns of a Row with type Street</param>
        public Street(string[] values)
        {
            Onrp = values[entryList[0]];
            StreetName = values[entryList[1]];
        }
    }
}
