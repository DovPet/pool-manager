using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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

        public string ApplicationUser_Id { get; set; }

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
        }
        public SessionFormViewModel(Session session)
        {
            Id = session.Id;
            Date = session.Date;
            Heading = session.Heading;
            Completed = session.Completed;
            DrillSetId = session.DrillSetId;


        }
    }
}