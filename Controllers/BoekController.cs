using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fric_frac.Controllers
{
    public class BoekController : Controller
    {
        private readonly DAL.IBook dalService;

        public BoekController(DAL.IBook dalService)
        {
            this.dalService = dalService;
        }

        public IActionResult Index()
        {
            BLL.Book boek = new BLL.Book();
            dalService.Boek = boek;
            dalService.ReadAll();
            return View(BLL.Book.List);
        }
    }
}