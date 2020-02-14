using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NinjaInfoCards.Models;

namespace NinjaInfoCards.Controllers
{
    public class HomeController : Controller
    {
        private Context _Context { get; set; }
        public HomeController (Context context)
        {
            this._Context = context;
        }

        [HttpGet ("")]
        public IActionResult Index ()
        {
            ViewBag.Ninjas = _Context.Ninjas;
            return View (new Ninja());
        }

        [HttpPost ("ninjas")]
        public IActionResult CreateNinja (Ninja myAwesomeNinjaYay)
        {
            if (ModelState.IsValid)
            {
                _Context.Ninjas.Add (myAwesomeNinjaYay);
                _Context.SaveChanges ();
                return Redirect ("/");
            }
            else
            {
                ViewBag.Ninjas = _Context.Ninjas;
                return View ("Index");
            }
        }

        [HttpGet ("ninja/{NinjaId}")]
        public IActionResult EditNinja (int NinjaId)
        {
            Ninja NinjaToEdit = _Context.Ninjas
                .FirstOrDefault(n => n.NinjaId==NinjaId);
            return View ("EditNinja", NinjaToEdit);
        }

        [HttpPost ("ninjas/update")]
        public IActionResult UpdateNinja (Ninja NinjaFromFormData)
        {
            if(ModelState.IsValid) 
            {
                NinjaFromFormData.Print();
                Ninja NinjaFromDB = _Context.Ninjas
                    .FirstOrDefault(n => n.NinjaId==NinjaFromFormData.NinjaId);
                NinjaFromDB.Name = NinjaFromFormData.Name;
                NinjaFromDB.Age = NinjaFromFormData.Age;
                NinjaFromDB.Village = NinjaFromFormData.Village;
                NinjaFromDB.UpdatedAt = DateTime.Now;
                _Context.SaveChanges();
                return Redirect("/");
            }
            else
            {
                return View("EditNinja", NinjaFromFormData);
            }
        }

        [HttpGet ("ninja/{NinjaId}/delete")]
        public IActionResult Remove(int NinjaId) {
            Ninja NinjaToRemove = _Context.Ninjas
                .FirstOrDefault(n => n.NinjaId==NinjaId);
            if(NinjaToRemove != null)
            {
                _Context.Ninjas.Remove(NinjaToRemove);
                _Context.SaveChanges();
            }
            return Redirect("/");
        }

    }
}