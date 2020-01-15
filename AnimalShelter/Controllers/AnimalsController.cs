using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalShelter.Controllers
{
    public class AnimalsController : Controller
    {
        private readonly AnimalShelterContext _db;
        public AnimalsController(AnimalShelterContext db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<Animal> model = _db.Animals.Include(animals => animals.Species).ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            ViewBag.SpeciesID = new SelectList(_db.Species, "ID", "Type");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Animal animal)
        {   
            _db.Animals.Add(animal);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Animal thisAnimal = _db.Animals.FirstOrDefault(animal => animal.ID == id);
            Species thisSpecies = _db.Species.FirstOrDefault(species => species.ID == thisAnimal.SpeciesID);
            ViewBag.Species = thisSpecies.Type;
            return View(thisAnimal);
        }
    }
}
