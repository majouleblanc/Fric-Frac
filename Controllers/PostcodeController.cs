using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fric_frac.Controllers
{
    public class PostcodeController : Controller
    {
        private readonly DAL.IPostcode dalService;

        public PostcodeController(DAL.IPostcode dalService)
        {
            this.dalService = dalService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Postcodes";
            ViewBag.Postcode = "Postcode";
            ViewBag.Plaats = "Plaats";
            ViewBag.Provincie = "Provincie";
            ViewBag.Localite = "Localité";
            ViewBag.Province = "Province";

            dalService.ReadAll();
            return View(BLL.Postcode.List);
        }

        public IActionResult PostcodeOrder()
        {
            ViewBag.Title = "Postcodes geordend op postcode";
            ViewBag.Postcode = "Postcode &#65516";
            ViewBag.Plaats = "Plaats";
            ViewBag.Provincie = "Provincie";
            ViewBag.Localite = "Localité";
            ViewBag.Province = "Province";

            dalService.ReadAll();
            return View("Index", BLL.Postcode.List.OrderBy(x => x.Code).ToList());
        }

        public IActionResult PlaatsOrder()
        {
            ViewBag.Title = "Postcodes";
            ViewBag.Postcode = "Postcode";
            ViewBag.Plaats = "Plaats &#65516";
            ViewBag.Provincie = "Provincie";
            ViewBag.Localite = "Localité";
            ViewBag.Province = "Province";

            ViewBag.Title = "Postcodes geordend op plaatsnaam";
            dalService.ReadAll();
            return View("Index", BLL.Postcode.List.OrderBy(x => x.Plaats).ToList());
        }

        public IActionResult ProvinceOrder()
        {
            ViewBag.Title = "Postcodes geordend op provincenaam";
            ViewBag.Postcode = "Postcode";
            ViewBag.Plaats = "Plaats";
            ViewBag.Provincie = "Provincie";
            ViewBag.Localite = "Localité";
            ViewBag.Province = "Province &#65516";

            dalService.ReadAll();
            return View("Index", BLL.Postcode.List.OrderBy(x => x.Province).ToList());
        }

        public IActionResult ProvincieOrder()
        {
            ViewBag.Title = "Postcodes geordend op provincienaam";
            ViewBag.Postcode = "Postcode";
            ViewBag.Plaats = "Plaats";
            ViewBag.Provincie = "Provincie &#65516";
            ViewBag.Localite = "Localité";
            ViewBag.Province = "Province";

            dalService.ReadAll();
            return View("Index", BLL.Postcode.List.OrderBy(x => x.Provincie).ToList());
        }

        public IActionResult LocaliteOrder()
        {
            ViewBag.Title = "Postcodes geordend op localitenaam";
            ViewBag.Postcode = "Postcode";
            ViewBag.Plaats = "Plaats";
            ViewBag.Provincie = "Provincie";
            ViewBag.Localite = "Localité &#65516";
            ViewBag.Province = "Province";

            dalService.ReadAll();
            return View("Index", BLL.Postcode.List.OrderBy(x => x.Localite).ToList());
        }

        
    }
}