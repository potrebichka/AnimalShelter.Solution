using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Controllers
{
    public class SpeciesController : Controller
    {
        private readonly AnimalShelterContext _db;
        public SpeciesController(AnimalShelterContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Species> model = _db.species.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Species species)
        {
            _db.species.Add(species);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Species thisSpecies = _db.species.FirstOrDefault(species => species.SpeciesId == id);
            return View(thisSpecies);
        }
    }
}