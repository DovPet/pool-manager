using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var results = from b in _context.Drills
                select new
                {
                    b.Id,
                    b.Heading,
                    Checked = ((from ab in _context.DrillsInSets
                                   where (ab.DrillSetId == id) & (ab.DrillId == b.Id)
                                   select ab).Count() > 0)

                };

            var myViewModel = new DrillSetsFormViewModel();

            myViewModel.Id = id;
            myViewModel.Heading = drillSet.Heading;
            myViewModel.Description = drillSet.Description;

            var checkboxList = new List<CheckBoxViewModel>();

            foreach (var item in results)
            {
                checkboxList.Add(new CheckBoxViewModel { Id = item.Id, Name = item.Heading, Checked = item.Checked });
            }


            myViewModel.Drills = checkboxList;
            return View("Details", myViewModel);
        }


        public ActionResult New()
        {

            if (User.IsInRole("Admin") | User.IsInRole("User"))
            {
                var viewModel = new DrillSetsFormViewModel();


                var results = from b in _context.Drills
                    select new
                    {
                        b.Id,
                        b.Heading
                        };

               var checkboxList = new List<CheckBoxViewModel>();

                foreach (var item in results)
                {
                    checkboxList.Add(new CheckBoxViewModel { Id = item.Id, Name = item.Heading});
                }


                viewModel.Drills = checkboxList;
                return View("DrillSetsForm", viewModel);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Save(DrillSetsFormViewModel drillSets)
        {
            if (User.IsInRole("Admin") | User.IsInRole("User"))
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = drillSets;

                    return View("DrillSetsForm", viewModel);
                }


                if (drillSets.Id == 0) { 
                    _context.DrillSets.Add(new DrillSet() {Heading = drillSets.Heading, Description = drillSets.Description });
                
                foreach (var item in _context.DrillsInSets)
                {
                    if (item.DrillSetId == drillSets.Id)
                    {
                        _context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in drillSets.Drills)
                {
                    if (item.Checked)
                    {
                        _context.DrillsInSets.Add(new DrillsInSet() {DrillSetId = drillSets.Id, DrillId = item.Id});
                    }
                }
                _context.SaveChanges();
                return Redirect("Index");
            }
            else
            {
                //var drillSets = new DrillSetsFormViewModel(drillSet);
                var MyDrillSet = _context.DrillSets.Find(drillSets.Id);

                MyDrillSet.Heading = drillSets.Heading;
                MyDrillSet.Description = drillSets.Description;

                foreach (var item in _context.DrillsInSets)
                {
                    if (item.DrillSetId == drillSets.Id)
                    {
                        _context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in drillSets.Drills)
                {
                    if (item.Checked)
                    {
                        _context.DrillsInSets.Add(new DrillsInSet() {DrillSetId = drillSets.Id, DrillId = item.Id});
                    }
                }
                _context.SaveChanges();
                return Redirect("Index");

            }

        }
            return RedirectToAction("Index", "DrillSets");

        }

        public ActionResult Edit(int id)
        {
            var drillSet = _context.DrillSets.SingleOrDefault(c => c.Id == id);
            if (drillSet == null)
                return HttpNotFound();
            var viewModel = new DrillSetsFormViewModel(drillSet);

            var results = from b in _context.Drills
                select new
                {
                    b.Id,
                    b.Heading,
                    Checked = ((from ab in _context.DrillsInSets
                                where (ab.DrillSetId == id) & (ab.DrillId == b.Id)
                                select ab).Count() > 0)

                };

            var myViewModel = new DrillSetsFormViewModel();

            myViewModel.Id = id;
            myViewModel.Heading = drillSet.Heading;
            myViewModel.Description = drillSet.Description;

            var checkboxList = new List<CheckBoxViewModel>();

            foreach (var item in results)
            {
                checkboxList.Add(new CheckBoxViewModel{ Id= item.Id, Name = item.Heading, Checked = item.Checked});
            }


            myViewModel.Drills = checkboxList;
            return View("DrillSetsForm", myViewModel);
        }


        [HttpPost]
        public ActionResult Edit(DrillSetsFormViewModel drillSets)
        {
            if (!ModelState.IsValid)
            {
                var MyDrillSet = _context.DrillSets.Find(drillSets.Id);

                MyDrillSet.Heading = drillSets.Heading;
                MyDrillSet.Description = drillSets.Description;

                foreach (var item in _context.DrillsInSets)
                {
                    if (item.DrillSetId == drillSets.Id)
                    {
                        _context.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                    }
                }

                foreach (var item in drillSets.Drills)
                {
                    if (item.Checked)
                    {
                        _context.DrillsInSets.Add(new DrillsInSet() {DrillSetId = drillSets.Id, DrillId = item.Id});
                    }
                }
                _context.SaveChanges();
                return Redirect("Index");
            }
            return View("List"); 
        }
    }
}