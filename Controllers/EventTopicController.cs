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
    public class EventTopicController : Controller
    {
        private readonly docent1Context dbContext;

        public EventTopicController(docent1Context dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "Fric-frac EventTopic Index";
            return View(dbContext.Eventtopic.ToList());
        }

        public IActionResult InsertingOne()
        {
            ViewBag.Title = "Fric-frac Country Inserting One";
            ViewBag.EventTopics = dbContext.Eventtopic.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult ReadingOne(int? id)
        {
            ViewBag.Message = "Fric-frac EventTopic Reading One";
            if (id == null)
            {
                return NotFound();
            }

            var eventTopic = dbContext.Eventtopic.SingleOrDefault(m => m.Id == id);
            ViewBag.EventTopics = dbContext.Eventtopic.ToList();

            if (eventTopic == null)
            {
                return NotFound();
            }
            return View(eventTopic);
        }

        //-----------------------------

        [HttpGet]
        public IActionResult UpdatingOne(int? id)
        {
            ViewBag.Title = "Fric-frac EventTopic Updating One";
            if (id == null)
            {
                return NotFound();
            }

            var eventTopic = dbContext.Eventtopic.SingleOrDefault(m => m.Id == id);
            ViewBag.EventTopics = dbContext.Eventtopic.ToList();

            if (eventTopic == null)
            {
                return NotFound();
            }
            return View(eventTopic);
        }

        [HttpPost]
        public IActionResult UpdateOne(Fric_frac.Models.FricFrac.Eventtopic eventTopic)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(eventTopic);
                    dbContext.SaveChanges();
                    ViewBag.EventTopics = dbContext.Eventtopic.ToList();
                    return View("ReadingOne", eventTopic);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dbContext.Eventtopic.Any(e => e.Id == eventTopic.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View("Index", eventTopic);
        }


        //--------------------------------------------------------------------------
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        //-----------------------------------------------------------------------

        [HttpPost]
        public IActionResult InsertOne(Fric_frac.Models.FricFrac.Eventtopic eventTopic)
        {
            ViewBag.Message = "Fric-frac eventTopic Inserting One";

            dbContext.Eventtopic.Add(eventTopic);
            dbContext.SaveChanges();
            ViewBag.EventTopics = dbContext.Eventtopic.ToList();
            return View("Index", dbContext.Eventtopic.ToList());
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
            var eventTopic = dbContext.Eventtopic.SingleOrDefault(m => m.Id == id);
            if (eventTopic == null)
            {
                return NotFound();
            }
            dbContext.Eventtopic.Remove(eventTopic);
            dbContext.SaveChanges();
            // keer terug naar de index pagina
            return RedirectToAction("Index");
        }
    }
}
