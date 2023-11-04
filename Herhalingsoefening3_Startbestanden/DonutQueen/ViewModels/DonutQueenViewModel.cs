using DonutQueen.Models;

namespace DonutQueen.ViewModels
{
    public class DonutQueenViewModel
    {
        public string Naam { get; set; }

        public List<Donut> Donuts { get; set; }

        public List<Winkel> Winkels { get; set; }
    }
}
