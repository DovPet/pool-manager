using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoolManager.Models;
using PoolManager.ViewModels;

namespace PoolManager.Controllers
{
    public class DrillSetsController : Controller
    {
        private ApplicationDbContext _context;

        public DrillSetsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ViewResult Index()
        {
            var drillSets = _context.DrillSets.ToList();

            if (User.IsInRole("Admin"))
            {
                return View("List", drillSets);
            }
           
                return View("UsersList", drillSets);

        }
        [Authorize(Roles = "User")]
        public ActionResult Details(int id)
        {
            var drillSet = _context.DrillSets.SingleOrDefault(c => c.Id == id);

            if (drillSet == null)
                return HttpNotFound();
            return View(drillSet);
        }


        public ActionResult New()
        {

            if (User.IsInRole("Admin"))
            {
                var viewModel = new DrillSetsFormViewModel();


                return View("DrillSetsForm", viewModel);
            }
            return HttpNotFound();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Save(DrillSet drillSet)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new DrillSetsFormViewModel(drillSet);

                return View("DrillSetsForm", viewModel);
            }

            if (drillSet.Id == 0)
                _context.DrillSets.Add(drillSet);
            else
            {
                var drillSetInDb = _context.DrillSets.Single(c => c.Id == drillSet.Id);

                //to update all properties
                //TryUpdateModel(customerInDb);

                drillSetInDb.Heading = drillSet.Heading;
                drillSetInDb.Description = drillSet.Description;

            }

            _context.SaveChanges();


            return RedirectToAction("Index", "DrillSets");
        }

        public ActionResult Edit(int id)
        {
            var drillSet = _context.DrillSets.SingleOrDefault(c => c.Id == id);
            if (drillSet == null)
                return HttpNotFound();
            var viewModel = new DrillSetsFormViewModel(drillSet);

            return View("DrillSetsForm", viewModel);
        }
    }
}