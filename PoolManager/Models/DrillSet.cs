using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoolManager.Models
{
    public class DrillSet
    {
        public DrillSet()
        {
            DrillsInSets = new List<DrillsInSet>();
        }

        public int Id { get; set; }

        [Required]
        public string Heading { get; set; }

        [Required]
        [AllowHtml]
        public string Description { get; set; }



        public virtual ICollection<DrillsInSet> DrillsInSets { get; set; }
        public ICollection<Statistic> Statistics { get; set; }
     
    }
}