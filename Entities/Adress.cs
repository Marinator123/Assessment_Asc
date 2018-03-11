namespace AdressLocator.Entities
{
    public class Adress
    {   

        public string Locality { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public Coordinate Coordinate { get; set; }
    }
}
