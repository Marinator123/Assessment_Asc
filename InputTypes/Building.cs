namespace AdressLocator.InputTypes
{
    /// <summary>
    ///     Class to describe Building Entities extracted from the input File
    /// </summary>
    internal class Building 
    {
        /// <summary>
        ///     The index of the columns of a building-row, which need to be described from a building-instance
        /// </summary>
        private static readonly int[] entryIndex = new int[]{ 2, 3 };
        /// <summary>
        ///     Foreign-key to an instance of the class Street
        /// </summary>
        internal string StreetId { get; }
        /// <summary>
        ///     The number of a building 
        /// </summary>
        internal string StreetNumber { get; }

        /// <summary>
        ///     Constructor of the Class Building which extracts all required attributes;
        /// </summary>
        /// <param name="values">An array of strings with all the Columns of a Row with type Building</param>
        internal Building(string[] values)
        {
            StreetId = values[entryIndex[0]];
            StreetNumber = values[entryIndex[1]];
        }
    }
}
