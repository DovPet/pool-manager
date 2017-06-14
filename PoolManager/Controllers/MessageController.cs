using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoolManager.Models;
using System.Data.Entity;
using PoolManager.ViewModels;

namespace PoolManager.Controllers
{
    public class MessageController : Controller
    {
        DateTime localDate = DateTime.Now;
        private ApplicationDbContext _context;

        public MessageController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Messages
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var messages = _context.Messages.Include(c => c.MessageTopic).ToList();
            return View("List", messages);
        }

        public ActionResult New()
        {
            var topics = _context.MessageTopics.ToList();
            var viewModel = new MessageFormViewModel()
            {
                MessageTopics = topics      
            };


            return View("MessageForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Message message)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MessageFormViewModel
                {
                    Message = message,
                    MessageTopics = _context.MessageTopics.ToList()
                };

                return View("MessageForm", viewModel);
            }

            if (message.Id == 0)
                _context.Messages.Add(message);
            else
            {
                var messageInDb = _context.Messages.Single(c => c.Id == message.Id);

                //to update all properties
                //TryUpdateModel(customerInDb);

                messageInDb.Text = message.Text;
                messageInDb.MessageTopicId = message.MessageTopicId;
                

            }

            _context.SaveChanges();

            TempData["Success"] = "Message Sent Successfully!";

            return RedirectToAction("New", "Message");
        }
    }
}