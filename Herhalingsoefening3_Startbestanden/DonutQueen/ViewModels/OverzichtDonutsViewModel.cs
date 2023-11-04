using DonutQueen.Models;

namespace DonutQueen.ViewModels
{
    public class OverzichtDonutsViewModel
    {
        public string Zoekterm { get; set; }

        public List<Donut> Donuts { get; set; }

        public Donut Donut { get; set; }
    }
}
