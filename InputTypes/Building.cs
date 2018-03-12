namespace AdressLocator.InputTypes
{
    /// <summary>
    ///     Class to describe Building Entities extracted from the input File
    /// </summary>
    class Building 
    {
        /// <summary>
        ///     The index of the columns of a building-row, which need to be described from a building-instance
        /// </summary>
        static readonly private int[] entryIndex = new int[]{ 2, 3 };
        /// <summary>
        ///     Foreign-key to an instance of the class Street
        /// </summary>
        public string StreetId { get; }
        /// <summary>
        ///     The number of a building 
        /// </summary>
        public string StreetNumber { get; }

        /// <summary>
        ///     Constructor of the Class Building which extracts all required attributes;
        /// </summary>
        /// <param name="values">An array of strings with all the Columns of a Row with type Building</param>
        public Building(string[] values)
        {
            StreetId = values[entryIndex[0]];
            StreetNumber = values[entryIndex[1]];
        }
    }
}
