namespace TrainingLambdasAndLinq.POCOS
{
    public class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public bool IsCapital { get; set; }

        public City(string name, string country, bool isCapital)
        {
            Name = name;
            Country = country;
            IsCapital = isCapital;
        }
    }
}
