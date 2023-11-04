namespace DonutQueen.Models
{
    public class Winkel
    {
        public int WinkelId { get; set; }

        public string Naam { get; set; }

        public string Straat { get; set; }

        public string Nummer { get; set; }

        public string Postcode { get; set; }

        public string Gemeente { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Afbeelding { get; set; }

        // Navigation Properties
        public List<Donut>? Donuts { get; set; }
    }
}
