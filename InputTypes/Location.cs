namespace AdressLocator.InputTypes
{
    /// <summary>
    ///     Class to describe Location Entities extracted from the input File
    /// </summary>
    internal class Location
    {
        /// <summary>
        ///     The index of the columns of a location-row, which need to be described from a location-instance
        /// </summary>
        private readonly static int[] entryIndex = new int[] { 4, 7 };
        /// <summary>
        ///     The postcode of a specific location e.g. 1000
        /// </summary>
        internal string Plz { get; }
        /// <summary>
        ///     The name of a Location e.g. Zurich
        /// </summary>
        internal string Locality { get; }

        /// <summary>
        ///     Constructor of the Class Location which extracts all required attributes;
        /// </summary>
        /// <param name="values">An array of strings with all the Columns of a Row with type Location</param>
        internal Location(string[] values)
        {
            Plz = values[entryIndex[0]];
            Locality = values[entryIndex[1]];
        }
    }
}
