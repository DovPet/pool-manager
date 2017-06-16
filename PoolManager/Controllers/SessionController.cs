using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using PoolManager.Models;
using PoolManager.ViewModels;

namespace PoolManager.Controllers
{
    public class SessionController : Controller
    {
        private ApplicationDbContext _context;

        public SessionController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = "User")]
        public ViewResult Index()
        {
            var session = _context.Sessions.Include(c => c.DrillSet).ToList();

            return View("List", session);

        }
        [Authorize(Roles = "User")]
        public ActionResult Details(int id)
        {
            var session = _context.Sessions.Include(c => c.DrillSet).SingleOrDefault(c => c.Id == id);

            if (session == null)
                return HttpNotFound();
            return View(session);
        }

        [Authorize(Roles = "User")]
        public ActionResult New()
        {
                var drillSets = _context.DrillSets.ToList();
                var viewModel = new SessionFormViewModel()
                {

                    DrillSets = drillSets
                };


            return View("SessionForm", viewModel);
            
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult Save(Session session)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new SessionFormViewModel(session);

                return View("SessionForm", viewModel);
            }

            if (session.Id == 0)
                _context.Sessions.Add(session);
            else
            {
                var sessionInDb = _context.Sessions.Single(c => c.Id == session.Id);

                //to update all properties
                //TryUpdateModel(customerInDb);
                sessionInDb.Date = session.Date;
                sessionInDb.Heading = session.Heading;
                sessionInDb.DrillSetId = session.DrillSetId;
                

            }

            _context.SaveChanges();


            return RedirectToAction("Index", "Session");
        }
        [Authorize(Roles = "User")]
        public ActionResult Edit(int id)
        {
            var session = _context.Sessions.SingleOrDefault(c => c.Id == id);
            if (session == null)
                return HttpNotFound();
            var viewModel = new SessionFormViewModel(session)
            {

                DrillSets = _context.DrillSets.ToList()

        };

            return View("SessionForm", viewModel);
        }
    }
}