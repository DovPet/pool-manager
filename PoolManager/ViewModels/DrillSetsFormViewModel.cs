using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoolManager.Models;

namespace PoolManager.ViewModels
{
    public class DrillSetsFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Heading { get; set; }

        [Required]
        [AllowHtml]
        public string Description { get; set; }
        
        public List<CheckBoxViewModel> Drills { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit DrillSet" : "New DrillSet";
            }
        }

        public DrillSetsFormViewModel()
        {
            Id = 0;
        }
        public DrillSetsFormViewModel(DrillSet drillSet)
        {
            Id = drillSet.Id;
            Heading = drillSet.Heading;
            Description = drillSet.Description;

        }
    }

    public class DrillsInSetsFormViewModel
    {
        public int Id { get; set; }
       
        public int DrillId { get; set; }
        public int DrillSetId { get; set; }

        public virtual Drill Drills { get; set; }

        public virtual DrillSet DrillSet { get; set; }
    }


}