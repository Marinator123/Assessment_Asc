namespace AdressLocator.Entities
{
    /// <summary>
    ///     The struct Adress with detailed information to describe an instance of adress.
    /// </summary>
    public struct Adress
    {   
        /// <summary>
        ///     The Locality of an Adress
        /// </summary>
        public string Locality { get; set; }
        /// <summary>
        ///     The postcode of an adress
        /// </summary>
        public string Zip { get; set; }
        /// <summary>
        ///     The Streetname of an Adress
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        ///     The Number of the Adress in its Street
        /// </summary>
        public string StreetNumber { get; set; }
        /// <summary>
        /// The longitude / latitude of a coordinate
        /// </summary>
        public Coordinate Coordinate { get; set; }
    }
}
