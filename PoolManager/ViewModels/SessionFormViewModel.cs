using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Principal;
using PoolManager.Models;

namespace PoolManager.ViewModels
{
    public class SessionFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Heading { get; set; }

        public string ApplicationUserId { get; set; }

        public bool Completed { get; set; }

        public int StatisticsId { get; set; }
        public virtual IEnumerable<DrillSet> DrillSets { get; set; }
        [Display(Name = "Drill Set")]
        public int DrillSetId { get; set; }

        public virtual ICollection<Statistic> Statistics { get; set; }


        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Session" : "New Session";
            }
        }

        public SessionFormViewModel()
        {
            Id = 0;
            ApplicationUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        }

        public SessionFormViewModel(Session session)
        {
            Id = session.Id;
            Date = session.Date;
            Heading = session.Heading;
            DrillSetId = session.DrillSetId;
            Completed = session.Completed;           
            ApplicationUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        }
    }
}