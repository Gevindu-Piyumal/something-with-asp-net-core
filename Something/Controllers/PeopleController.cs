using Microsoft.AspNetCore.Mvc;
using Something.Data;
using Something.Models;

namespace Something.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PeopleController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<People> objPeopleList = _db.People;
            return View(objPeopleList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(People obj)
        {
            if (ModelState.IsValid)
            {
                _db.People.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Data added successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var peopleFromDb = _db.People.Find(id);
            if (peopleFromDb == null)
            {
                return NotFound();
            }
            return View(peopleFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(People obj)
        {
            if (ModelState.IsValid)
            {
                _db.People.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Data updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var peopleFromDb = _db.People.Find(id);
            if (peopleFromDb == null)
            {
                return NotFound();
            }
            return View(peopleFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(People obj)
        {
            if (obj == null)
            {
                return NotFound();
            }
            var peopleFromDb = _db.People.Find(obj.Id);
            if (peopleFromDb == null)
            {
                return NotFound();
            }
            _db.People.Remove(peopleFromDb);
            _db.SaveChanges();
            TempData["success"] = "Data deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
