namespace AdressLocator.InputTypes
{
    /// <summary>
    ///     Class to describe Street Entities extracted from the input File
    /// </summary>
    internal class Street
    {
        /// <summary>
        ///     The index of the columns of a street-row, which need to be described from a street-instance
        /// </summary>
        private readonly static int[] entryIndex = new int[] { 2, 4 };
        /// <summary>
        ///     Foreign-key to an instance of the class Locations (Ordnungsnummer Post)
        /// </summary>
        internal string Onrp { get; }
        /// <summary>
        ///     The name of the Street
        /// </summary>
        internal string StreetName { get; }

        /// <summary>
        ///     Constructor of the Class Street which extracts all required attributes;
        /// </summary>
        /// <param name="values">An array of strings with all the Columns of a Row with type Street</param>
        internal Street(string[] values)
        {
            Onrp = values[entryIndex[0]];
            StreetName = values[entryIndex[1]];
        }
    }
}
