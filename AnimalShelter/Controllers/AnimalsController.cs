using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

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
            List<Animal> model = _db.animals.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Animal animal)
        {
            _db.animals.Add(animal);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Animal thisAnimal = _db.animals.FirstOrDefault(animal => animal.AnimalId == id);
            return View(thisAnimal);
        }
    }
}
