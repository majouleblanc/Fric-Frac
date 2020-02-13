using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fric_frac.Models.FricFrac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fric_frac.Controllers
{
    public class PersonController : Controller
    {
        private readonly docent1Context dbContext;

        public PersonController(docent1Context dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "Fric-frac Person Index";
            return View(dbContext.Person.ToList());
        }

        //-------------------------INSERTING----------------------------
        public IActionResult InsertingOne()
        {
            ViewBag.Title = "Fric-frac Person Inserting One";
            ViewBag.Countries = dbContext.Country.ToList();
            ViewBag.Personen = dbContext.Person.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult InsertOne(Models.FricFrac.Person person)
        {
            ViewBag.Message = "Insert een persoon in de database";
            dbContext.Person.Add(person);
            dbContext.SaveChanges();
            return View("Index", dbContext.Person.ToList());
        }


        //------------------------READING-----------------------------------
        [HttpGet]
        public IActionResult ReadingOne(int? id)
        {
            ViewBag.Message = "Lees een Persoon in de database";
            if (id == null)
            {
                return NotFound();
            }

            var person = dbContext.Person.SingleOrDefault(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            person.Country = dbContext.Country.SingleOrDefault(m => m.Id == person.CountryId);
            ViewBag.Personen = dbContext.Person.ToList();
            return View(person);
        }

        //-----------------------------UPDATING---------------

        public IActionResult UpdatingOne(int? id)
        {
            ViewBag.Title = "Fric-frac Person Updating One";
            if (id == null)
            {
                return NotFound();
            }
            var person = dbContext.Person.SingleOrDefault(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            person.Country = dbContext.Country.SingleOrDefault(m => m.Id == person.CountryId);
            ViewBag.Countries = dbContext.Country.ToList();
            ViewBag.Personen = dbContext.Person.ToList();
            return View(person);
        }
    

    [HttpPost]
    public IActionResult UpdateOne(Models.FricFrac.Person person)
    {
        if (ModelState.IsValid)
        {
            try
            {
                dbContext.Update(person);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!dbContext.Person.Any(e => e.Id == person.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }
        return View("Index", dbContext.Person);
    }


    //---------------------------------CANCEL-----------------------------------------
    public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        //--------------------------------DELETE-----------------------------------------
        // GET: Supplier/Delete/5
        //in de praktijk better via Post
        public IActionResult DeleteOne(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var person = dbContext.Person.SingleOrDefault(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            dbContext.Person.Remove(person);
            dbContext.SaveChanges();
            // keer terug naar de index pagina
            return RedirectToAction("Index");
        }
    }
}
