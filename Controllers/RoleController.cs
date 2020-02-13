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
    public class RoleController : Controller
    {
        private readonly docent1Context dbContext;

        public RoleController(docent1Context dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "Fric-frac Role Index";
            return View(dbContext.Role.ToList());
        }

        public IActionResult InsertingOne()
        {
            ViewBag.Title = "Fric-frac Country Inserting One";
            ViewBag.Roles = dbContext.Role.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult ReadingOne(int? id)
        {
            ViewBag.Message = "Fric-frac Role Reading One";
            if (id == null)
            {
                return NotFound();
            }

            var Role = dbContext.Role.SingleOrDefault(m => m.Id == id);
            ViewBag.Roles = dbContext.Role.ToList();

            if (Role == null)
            {
                return NotFound();
            }
            return View(Role);
        }

        //-----------------------------

        [HttpGet]
        public IActionResult UpdatingOne(int? id)
        {
            ViewBag.Title = "Fric-frac Role Updating One";
            if (id == null)
            {
                return NotFound();
            }

            var Role = dbContext.Role.SingleOrDefault(m => m.Id == id);
            ViewBag.Roles = dbContext.Role.ToList();

            if (Role == null)
            {
                return NotFound();
            }
            return View(Role);
        }

        [HttpPost]
        public IActionResult UpdateOne(Fric_frac.Models.FricFrac.Role Role)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(Role);
                    dbContext.SaveChanges();
                    ViewBag.Roles = dbContext.Role.ToList();
                    return View("ReadingOne", Role);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dbContext.Role.Any(e => e.Id == Role.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View("Index", Role);
        }


        //--------------------------------------------------------------------------
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }

        //-----------------------------------------------------------------------

        [HttpPost]
        public IActionResult InsertOne(Fric_frac.Models.FricFrac.Role Role)
        {
            ViewBag.Message = "Fric-frac Role Inserting One";

            dbContext.Role.Add(Role);
            dbContext.SaveChanges();
            return View("Index", dbContext.Role.ToList());
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
            var Role = dbContext.Role.SingleOrDefault(m => m.Id == id);
            if (Role == null)
            {
                return NotFound();
            }
            dbContext.Role.Remove(Role);
            dbContext.SaveChanges();
            // keer terug naar de index pagina
            return RedirectToAction("Index");
        }
    }
}
