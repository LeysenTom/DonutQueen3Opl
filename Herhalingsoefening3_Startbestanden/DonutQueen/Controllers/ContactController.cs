using DonutQueen.Models;
using DonutQueen.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DonutQueen.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactViewModel vm)
        {
            if(ModelState.IsValid)
            {
                Bericht bericht = new Bericht();
                bericht.BerichtId = 1;
                bericht.Voornaam = vm.Bericht.Voornaam;
                bericht.Achternaam = vm.Bericht.Achternaam;
                bericht.Email = vm.Bericht.Email;
                bericht.Boodschap = vm.Bericht.Boodschap;

                ContactViewModel viewModel = new()
                {
                    Bericht = bericht
                };

                return View("Bevestiging", viewModel);
            }

            return View(vm);
        }
    }
}
