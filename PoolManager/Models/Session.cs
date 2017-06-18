using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PoolManager.Models
{
    public class Session
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Heading { get; set; }

       
        [Required]
        public bool Completed { get; set; }

        [ForeignKey("StatisticsId")]
        public virtual IEnumerable<Statistic> Statistics { get; set; }
        [Required]
        public virtual int? StatisticsId { get; set; }

        public virtual DrillSet DrillSet { get; set; }
        [Required]
        public int DrillSetId { get; set; }

        public virtual IEnumerable<ApplicationUser> AspNetUsers { get; set; }
        [Required]
        [StringLength(128)]
        public string ApplicationUserId { get; set; }
    }
}