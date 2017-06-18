using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PoolManager.Models;
using PoolManager.ViewModels;

namespace PoolManager.Controllers
{
    public class StatisticsController : Controller
    {
        DateTime localDate = DateTime.Now;
        private ApplicationDbContext _context;

        public StatisticsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

       /* [Authorize(Roles = "User")]
        public ViewResult Index()
        {
            var statistics = _context.Statistics.ToList();

            return View("Index", statistics);

        }*/
        [Authorize(Roles = "User")]

        public ActionResult Details(int id)
        {
            var statistics = _context.Statistics.SingleOrDefault(c => c.Id == id);

            if (statistics == null)
                return HttpNotFound();
            return View(statistics);
        }

        [Authorize(Roles = "User")]
        public ActionResult New()
        {
            var viewModel = new StatisticsFormViewModel();
           
            return View("New", viewModel);

        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public ActionResult Save(Statistic statistic)
        {
            Console.WriteLine(localDate.ToString("h:mm:ss tt"));
            if (!ModelState.IsValid)
            {
                var viewModel = new StatisticsFormViewModel(statistic);
                

                return View("New", viewModel);
            }

            if (statistic.Id == 0)
                _context.Statistics.Add(statistic);
            else
            {
                var statisticInDb = _context.Statistics.Single(c => c.Id == statistic.Id);

                //to update all properties
                //TryUpdateModel(sessionInDb);
                
                statisticInDb.SetsDone = (from b in _context.Sessions
                    where (b.ApplicationUserId == statistic.ApplicationUserId) && (b.Completed == true)
                    select b.DrillSetId).Count();
                    

                statisticInDb.DrillsDone = statistic.DrillsDone;
                statisticInDb.DrillsFailed = statistic.DrillsFailed;

                statisticInDb.DrillSetsFailed = (from b in _context.Sessions
                    where (b.ApplicationUserId == statistic.ApplicationUserId) && (b.Completed == false)
                    select b.DrillSetId).Count();
                statisticInDb.ApplicationUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            }

            _context.SaveChanges();


            return RedirectToAction("New", "Session");
        }

       /* [Authorize(Roles = "User")]
        public ActionResult Edit(int id)
        {
            var statistics = _context.Statistics.SingleOrDefault(c => c.Id == id);
            if (statistics == null)
                return HttpNotFound();
            var viewModel = new StatisticsFormViewModel(statistics);

            return View("", viewModel);
        }*/
    }
}