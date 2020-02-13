using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fric_frac.Models.FricFrac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FricFrac.Controllers
{
    public class CountryController : Controller
    {
        private readonly docent1Context dbContext;

        public CountryController(docent1Context dbContext)
        {
            this.dbContext = dbContext;
        }


        public IActionResult Index()
        {
            ViewBag.Title = "Fric-frac Country Index";
            return View(dbContext.Country.ToList());
        }

        public IActionResult InsertingOne()
        {
            ViewBag.Title = "Fric-frac Country Inserting One";
            ViewBag.Countries = dbContext.Country.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult ReadingOne(int? id)
        {
            ViewBag.Message = "Toont een land in de database";
            if (id == null)
            {
                return NotFound();
            }

            var country = dbContext.Country.SingleOrDefault(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            ViewBag.Countries = dbContext.Country.ToList();
            return View(country);
        }

        [HttpGet]
        public IActionResult UpdatingOne(int? id)
        {
            ViewBag.Title = "Fric-frac Country Updating One";
            if (id == null)
            {
                return NotFound();
            }

            var country = dbContext.Country.SingleOrDefault(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            ViewBag.Countries = dbContext.Country.ToList();
            return View(country);
        }

        [HttpPost]
        public IActionResult UpdateOne(Fric_frac.Models.FricFrac.Country country)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(country);
                    dbContext.SaveChanges();
                    ViewBag.Countries = dbContext.Country.ToList();
                    return View("ReadingOne", country);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dbContext.Country.Any(e => e.Id == country.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View("Index", country);
        }

        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult InsertOne(Fric_frac.Models.FricFrac.Country Country)
        {
            ViewBag.Message = "Insert een land in de database";
            dbContext.Country.Add(Country);
            dbContext.SaveChanges();
            return View("Index", dbContext.Country.ToList<Country>());
        }

        // GET: Supplier/Delete/5
        //in de praktijk better via Post
        public IActionResult DeleteOne(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // zoek het land dat verwijderd moet worden
            var country = dbContext.Country.SingleOrDefault(m => m.Id == id);
            if (country == null)
            {
                return NotFound();
            }
            dbContext.Country.Remove(country);
            dbContext.SaveChanges();
            // keer terug naar de index pagina
            return RedirectToAction("Index");
        }
    }
}