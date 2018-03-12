namespace AdressLocator.Entities
{
    /// <summary>
    ///     The struct Adress with detailed information to describe an instance of adress.
    /// </summary>
    internal struct Adress
    {   
        /// <summary>
        ///     The Locality of an Adress
        /// </summary>
        internal string Locality { get; set; }
        /// <summary>
        ///     The postcode of an adress
        /// </summary>
        internal string Zip { get; set; }
        /// <summary>
        ///     The Streetname of an Adress
        /// </summary>
        internal string Street { get; set; }
        /// <summary>
        ///     The Number of the Adress in its Street
        /// </summary>
        internal string StreetNumber { get; set; }
        /// <summary>
        /// The longitude / latitude of a coordinate
        /// </summary>
        internal Coordinate Coordinate { get; set; }
    }
}
