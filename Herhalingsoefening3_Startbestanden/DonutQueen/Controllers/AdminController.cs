using DonutQueen.Data;
using DonutQueen.Data.UnitOfWork;
using DonutQueen.Models;
using DonutQueen.ViewModels.AdminViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DonutQueen.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _context;
        private readonly IWebHostEnvironment _environment;

        public AdminController(IUnitOfWork context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DonutCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                await _context.DonutRepository.AddAsync(new Donut()
                {
                    Naam = viewModel.Naam,
                    Omschrijving = viewModel.Omschrijving,
                    Vulling = viewModel.Vulling ?? "",
                    Topping = viewModel.Topping ?? "",
                    Glazuur = viewModel.Glazuur ?? "",
                    IsVegan = viewModel.IsVegan.Value,
                    Afbeelding = Upload(viewModel.Bestand)
                });

                System.Diagnostics.Debug.WriteLine(viewModel.Bestand);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var donut = await _context.DonutRepository.GetByIdAsync(id);

            if (donut != null)
            {
                _context.DonutRepository.Delete(donut);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"{id} not found!");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var donut = await _context.DonutRepository.GetByIdAsync(id);

            if (donut == null) { return NotFound(); }

            DonutEditViewModel viewModel = new DonutEditViewModel()
            {
                DonutId = donut.DonutId,
                Naam = donut.Naam,
                Omschrijving = donut.Omschrijving,
                Vulling = donut.Vulling,
                Topping = donut.Topping,
                Glazuur = donut.Glazuur,
                IsVegan = donut.IsVegan ?? false,
                Afbeelding = donut.Afbeelding
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DonutEditViewModel viewModel)
        {
            if (id != viewModel.DonutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Donut donut = new Donut()
                    {
                        DonutId = viewModel.DonutId,
                        Naam = viewModel.Naam,
                        Omschrijving = viewModel.Omschrijving,
                        Vulling = viewModel.Vulling,
                        Topping = viewModel.Topping,
                        Glazuur = viewModel.Glazuur,
                        IsVegan = viewModel.IsVegan ?? false,
                        Afbeelding = Upload(viewModel.Bestand)
                    };

                    _context.DonutRepository.Update(donut);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (_context.DonutRepository.Search().Where(x => x.DonutId == id) != null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Index()
        {
            DonutViewModel vm = new DonutViewModel();
            var donutLijst = await _context.DonutRepository.GetAllAsync();
            vm.Donuts = donutLijst.ToList();

            return View(vm);
        }

        private string Upload(IFormFile bestand)
        {
            if (bestand != null && bestand.Length > 0)
            {
                string path = Path.Combine(_environment.WebRootPath, "images");

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(bestand.FileName);

                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    bestand.CopyTo(stream);
                    return fileName;
                }
            }

            return null;
        }
    }
}