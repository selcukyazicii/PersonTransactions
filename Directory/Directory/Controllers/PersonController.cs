using Directory.Data;
using Directory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Directory.Controllers
{
    public class PersonController : Controller
    {
        private readonly PersonalDbContext _personalDbContext;
        public PersonController(PersonalDbContext personalDbContext)
        {
            _personalDbContext = personalDbContext;
        }
        public IActionResult Index()
        {
           
            IEnumerable<Person> person = _personalDbContext.Person;
            return View(person);
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {

            if (ModelState.IsValid == true)
            {
                _personalDbContext.Person.Add(person);
                _personalDbContext.SaveChanges();
                return RedirectToAction("Index", "Person");
            }
            return View(person);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var person = _personalDbContext.Person.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }
        [HttpPost]
        public IActionResult Edit(Person person)
        {
            if (ModelState.IsValid == true)
            {
                _personalDbContext.Person.Update(person);
                _personalDbContext.SaveChanges();
                return RedirectToAction("Index", "Person");
            }
            return View(person);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var person = _personalDbContext.Person.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var person = _personalDbContext.Person.Find(id);
            if (person == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _personalDbContext.Person.Remove(person);
                _personalDbContext.SaveChanges();
                return RedirectToAction("Index", "Person");
            }
            return View();
        }
        public IActionResult Details(int? id)
        {
            using var context = new PersonalDbContext();
            var person = context.Person.Find(id);

            return View(person);
        }

    }
}

