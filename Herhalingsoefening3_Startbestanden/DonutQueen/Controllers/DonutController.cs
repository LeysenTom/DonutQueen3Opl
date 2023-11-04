using DonutQueen.Data;
using DonutQueen.Models;
using DonutQueen.ViewModels;
using DonutQueen.ViewModels.AdminViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DonutQueen.Controllers
{
    public class DonutController : Controller
    {
        private readonly DonutQueenContext _context;

        public DonutController(DonutQueenContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            OverzichtDonutsViewModel vm = new OverzichtDonutsViewModel();
            vm.Donuts = _context.Donuts.ToList();

            return View(vm);
        }

        public IActionResult FilterDonuts(OverzichtDonutsViewModel vm)
        {
            if (!string.IsNullOrEmpty(vm.Zoekterm))
            {
                vm.Donuts = _context.Donuts.Where(donut => donut.Naam.Contains(vm.Zoekterm)).ToList();
            }
            else
            {
                vm.Donuts = _context.Donuts.ToList();
            }

            return View("Index", vm);
        }
    }
}
