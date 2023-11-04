using DonutQueen.Data;
using DonutQueen.Models;
using DonutQueen.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DonutQueen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DonutQueenContext _context;

        public HomeController(DonutQueenContext context, ILogger<HomeController> logger)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            DonutQueenViewModel vm = new DonutQueenViewModel();
            vm.Donuts = _context.Donuts.ToList();

            return View(vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}