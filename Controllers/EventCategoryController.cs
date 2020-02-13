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
    public class EventCategoryController : Controller
    {
        private readonly docent1Context dbContext;

        public EventCategoryController(docent1Context dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "Fric-frac EventCategory Index";
            return View(dbContext.Eventcategory.ToList());
        }

        public IActionResult InsertingOne()
        {
            ViewBag.Title = "Fric-frac Country Inserting One";
            ViewBag.EventCategories = dbContext.Eventcategory.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult ReadingOne(int? id)
        {
            ViewBag.Message = "Fric-frac EventCategory Reading One";
            if (id == null)
            {
                return NotFound();
            }

            var eventCategory = dbContext.Eventcategory.SingleOrDefault(m => m.Id == id);
            ViewBag.EventCategories = dbContext.Eventcategory.ToList();

            if (eventCategory == null)
            {
                return NotFound();
            }
            return View(eventCategory);
        }

        //-----------------------------
        
        [HttpGet]
        public IActionResult UpdatingOne(int? id)
        {
            ViewBag.Title = "Fric-frac EventCategory Updating One";
            if (id == null)
            {
                return NotFound();
            }

            var eventCategory = dbContext.Eventcategory.SingleOrDefault(m => m.Id == id);
            ViewBag.EventCategories = dbContext.Eventcategory.ToList();

            if (eventCategory == null)
            {
                return NotFound();
            }
            return View(eventCategory);
        }

        [HttpPost]
        public IActionResult UpdateOne(Fric_frac.Models.FricFrac.Eventcategory eventCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(eventCategory);
                    dbContext.SaveChanges();
                    ViewBag.EventCategories = dbContext.Eventcategory.ToList();
                    return View("ReadingOne", eventCategory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dbContext.Eventcategory.Any(e => e.Id == eventCategory.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View("Index", eventCategory);
        }


        //--------------------------------------------------------------------------
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        //-----------------------------------------------------------------------
        
        [HttpPost]
        public IActionResult InsertOne(Fric_frac.Models.FricFrac.Eventcategory eventCategory)
        {
            ViewBag.Message = "Fric-frac EventCategory Inserting One";
            
            dbContext.Eventcategory.Add(eventCategory);
            dbContext.SaveChanges();
            return View("Index", dbContext.Eventcategory.ToList());
        }

        //-------------------------------------------------------------------------
        // GET: Supplier/Delete/5
        //in de praktijk better via Post
        public IActionResult DeleteOne(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // zoek het land dat verwijderd moet worden
            var eventCategory = dbContext.Eventcategory.SingleOrDefault(m => m.Id == id);
            if (eventCategory == null)
            {
                return NotFound();
            }
            dbContext.Eventcategory.Remove(eventCategory);
            dbContext.SaveChanges();
            // keer terug naar de index pagina
            return RedirectToAction("Index");
        }
    }
}
