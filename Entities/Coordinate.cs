namespace AdressLocator.Entities
{
    /// <summary>
    ///     The Struct Coordinate with information about latitude and longitude
    /// </summary>
    internal struct Coordinate
    {
        /// <summary>
        ///     The latitude of a Coordinate
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        ///     The longitude of a Coordinate
        /// </summary>
        public string Longitude { get; set; }
    }
}