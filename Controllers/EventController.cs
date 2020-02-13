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
    public class EventController : Controller
    {
        private readonly docent1Context dbContext;

        public EventController(docent1Context dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "Fric-frac Event Index";
            return View(dbContext.Event.ToList());
        }

        //-------------------------INSERTING----------------------------
        public IActionResult InsertingOne()
        {
            ViewBag.Title = "Fric-frac Event Inserting One";
            ViewBag.Eventcategories = dbContext.Eventcategory.ToList();   //--------!!!!!!!
            ViewBag.Eventtopics = dbContext.Eventtopic.ToList();   //--------!!!!!!!
            ViewBag.Events = dbContext.Event.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult InsertOne(Models.FricFrac.Event Event)
        {
            ViewBag.Message = "Insert een persoon in de database";
            dbContext.Event.Add(Event);
            dbContext.SaveChanges();
            return View("Index", dbContext.Event.ToList());
        }


        //------------------------READING-----------------------------------
        [HttpGet]
        public IActionResult ReadingOne(int? id)
        {
            ViewBag.Message = "Lees een event in de database";
            if (id == null)
            {
                return NotFound();
            }

            var Event = dbContext.Event.SingleOrDefault(m => m.Id == id);
            if (Event == null)
            {
                return NotFound();
            }
            Event.Eventcategory = dbContext.Eventcategory.SingleOrDefault(m => m.Id == Event.EventcategoryId);
            Event.Eventtopic = dbContext.Eventtopic.SingleOrDefault(m => m.Id == Event.EventtopicId);
            ViewBag.Events = dbContext.Event.ToList();

            return View(Event);
        }

        //----------------------UPDATING---------------------------------------

        public IActionResult UpdatingOne(int? id)
        {
            ViewBag.Title = "Fric-frac Event Updating One";
            if (id == null)
            {
                return NotFound();
            }
            var Event = dbContext.Event.SingleOrDefault(m => m.Id == id);
            if (Event == null)
            {
                return NotFound();
            }
            Event.Eventcategory = dbContext.Eventcategory.SingleOrDefault(m => m.Id == Event.EventcategoryId);
            Event.Eventcategory = dbContext.Eventcategory.SingleOrDefault(m => m.Id == Event.EventcategoryId);

            ViewBag.Eventcategories = dbContext.Eventcategory.ToList();
            ViewBag.Eventtopics = dbContext.Eventtopic.ToList();
            ViewBag.Events = dbContext.Event.ToList();

            return View(Event);
        }


        [HttpPost]
        public IActionResult UpdateOne(Models.FricFrac.Event Event)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(Event);
                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dbContext.Event.Any(e => e.Id == Event.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View("Index", dbContext.Event.ToList());
        }


        //--------------------------------------------------------------------------
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
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
            var Event = dbContext.Event.SingleOrDefault(m => m.Id == id);
            if (Event == null)
            {
                return NotFound();
            }
            dbContext.Event.Remove(Event);
            dbContext.SaveChanges();
            // keer terug naar de index pagina
            return RedirectToAction("Index");
        }
    }
}
