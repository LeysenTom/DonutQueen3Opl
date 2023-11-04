using DonutQueen.Models;

namespace DonutQueen.ViewModels.AdminViewModels
{
    public class DonutViewModel
    {
        public int DonutId { get; set; }

        public string Zoekterm { get; set; }

        public List<Donut> Donuts { get; set; }

        public Donut Donut { get; set; }
    }
}
