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
    public class UserController : Controller
    {
        private readonly docent1Context dbContext;

        public UserController(docent1Context dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "Fric-frac User Index";
            return View(dbContext.User.ToList());
        }

        //-------------------------INSERTING----------------------------
        public IActionResult InsertingOne()
        {
            ViewBag.Title = "Fric-frac User Inserting One";
            ViewBag.Persons = dbContext.Person.ToList();   //--------!!!!!!!
            ViewBag.Rols = dbContext.Role.ToList();   //--------!!!!!!!
            ViewBag.Users = dbContext.User.ToList();
            return View();
        }


        [HttpPost]
        public IActionResult InsertOne(Models.FricFrac.User User)
        {
            ViewBag.Message = "Insert een persoon in de database";
            dbContext.User.Add(User);
            dbContext.SaveChanges();
            ViewBag.Users = dbContext.User.ToList();

            return View("Index", dbContext.User.ToList());
        }


        //------------------------READING-----------------------------------
        [HttpGet]
        public IActionResult ReadingOne(int? id)
        {
            ViewBag.Message = "Lees een User in de database";
            if (id == null)
            {
                return NotFound();
            }

            var User = dbContext.User.SingleOrDefault(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }
            User.Person = dbContext.Person.SingleOrDefault(m => m.Id == User.PersonId);        //-----------------------   
            User.Role = dbContext.Role.SingleOrDefault(m => m.Id == User.RoleId);              //----!!!!!!!!!!!!!!!!!
            ViewBag.Users = dbContext.User.ToList();

            return View(User);
        }

        //----------------------UPDATING---------------------------------------

        public IActionResult UpdatingOne(int? id)
        {
            ViewBag.Title = "Fric-frac User Updating One";
            if (id == null)
            {
                return NotFound();
            }
            var User = dbContext.User.SingleOrDefault(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }
            User.Person = dbContext.Person.SingleOrDefault(m => m.Id == User.PersonId);
            User.Role = dbContext.Role.SingleOrDefault(m => m.Id == User.RoleId);

            ViewBag.Persons = dbContext.Person.ToList();
            ViewBag.Rols = dbContext.Role.ToList();
            ViewBag.Users = dbContext.User.ToList();

            return View(User);
        }


        [HttpPost]
        public IActionResult UpdateOne(Models.FricFrac.User User)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Update(User);
                    dbContext.SaveChanges();
                    ViewBag.Users = dbContext.User.ToList();

                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dbContext.User.Any(e => e.Id == User.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View("Index", dbContext.User.ToList());
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
            var User = dbContext.User.SingleOrDefault(m => m.Id == id);
            if (User == null)
            {
                return NotFound();
            }
            dbContext.User.Remove(User);
            dbContext.SaveChanges();
            // keer terug naar de index pagina
            return RedirectToAction("Index");
        }
    }
}
