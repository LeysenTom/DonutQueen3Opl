using DonutQueen.Models;
using DonutQueen.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DonutQueen.Controllers
{
    public class WinkelController : Controller
    {
        public List<Winkel> winkels = new List<Winkel>()
        {
            new Winkel() { WinkelId = 1, Naam = "Campus Lier", Straat = "Antwerpsestraat", Nummer = "99", Postcode = "2500", Gemeente = "Lier", Latitude = 51.1336114, Longitude = 4.5666362, Afbeelding = "/images/location.jpg"},
            new Winkel() { WinkelId = 2, Naam = "Campus Turnhout", Straat = "Campus Blairon", Nummer = "800", Postcode = "2300", Gemeente = "Turnhout", Latitude = 51.317218, Longitude = 4.9291412, Afbeelding = "/images/location.jpg"},
            new Winkel() { WinkelId = 3, Naam = "Campus Geel", Straat = "Kleinhoefstraat", Nummer = "4", Postcode = "2440", Gemeente = "Geel", Latitude = 51.1568249, Longitude = 4.9676239, Afbeelding = "/images/location.jpg"},
        };

        public IActionResult Index()
        {
            DonutQueenViewModel vm = new DonutQueenViewModel();
            vm.Winkels = winkels;

            return View(vm);
        }
    }
}
