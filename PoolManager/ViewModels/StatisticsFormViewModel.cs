using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using PoolManager.Models;

namespace PoolManager.ViewModels
{

    public class StatisticsFormViewModel
    {
        DateTime localDate = DateTime.Now;
        DateTime dt = DateTime.Parse("6/22/2009 07:00:00 AM");
        public int Id { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime FinishDate { get; set; }

        public int SetsDone { get; set; }

        public int DrillsDone { get; set; }

        public int DrillsFailed { get; set; }

        public int DrillSetsFailed { get; set; }

        [ForeignKey("ApplicationUserId")]
        public virtual IEnumerable<ApplicationUser> AspNetUsers { get; set; }
        [Required]
        [StringLength(128)]
        public string ApplicationUserId { get; set; }

        public StatisticsFormViewModel()
        {
            Id = 0;
            ApplicationUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            StartDate = dt;
            SetsDone = 0;
            DrillsDone = 0;
            DrillsFailed = 0;
            DrillSetsFailed = 0;
        }

        public StatisticsFormViewModel(Statistic statistics)
        {
            Id = statistics.Id;
            StartDate = statistics.StartDate;
            SetsDone = statistics.SetsDone;
            DrillsDone = statistics.DrillsDone;
            DrillsFailed = statistics.DrillsFailed;
            DrillSetsFailed = statistics.DrillSetsFailed;
            ApplicationUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

        }
    }
}