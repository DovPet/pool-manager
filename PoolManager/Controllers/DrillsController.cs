using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoolManager.Models;
using PoolManager.ViewModels;

namespace PoolManager.Controllers
{
    public class DrillsController : Controller
    {
        private ApplicationDbContext _context;

        public DrillsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            var drills = _context.Drills.ToList();

            if (User.IsInRole("Admin"))
            {
                return View("List",drills);
            }
            if (User.IsInRole("User"))
            {
                return View("UsersList",drills);
            }

            return View("ReadOnlyList",drills);

        }
        [Authorize(Roles = "User")]
        public ActionResult Details(int id)
        {
            var drill = _context.Drills.SingleOrDefault(c => c.Id == id);

            if (drill == null)
                return HttpNotFound();
            return View(drill);
        }

       
        public ActionResult New()
        {
            if (User.IsInRole("Admin"))
            {
                var viewModel = new DrillsFormViewModel();


                return View("DrillsForm", viewModel);
            }
            return HttpNotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Save(Drill drill)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DrillsFormViewModel(drill);
               
                return View("DrillsForm", viewModel);
            }

            if (drill.Id == 0)
                _context.Drills.Add(drill);
            else
            {
                var drillInDb = _context.Drills.Single(c => c.Id == drill.Id);

                //to update all properties
                //TryUpdateModel(customerInDb);

                drillInDb.Heading = drill.Heading;
                drillInDb.Description = drill.Description;
                
            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Drills");
        }
        
        public ActionResult Edit(int id)
        {
            var drill = _context.Drills.SingleOrDefault(c => c.Id == id);
            if (drill == null)
                return HttpNotFound();
            var viewModel = new DrillsFormViewModel(drill);
            
            return View("DrillsForm", viewModel);
        }
    }
}