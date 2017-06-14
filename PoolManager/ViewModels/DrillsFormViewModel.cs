using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoolManager.Models;

namespace PoolManager.ViewModels
{
    public class DrillsFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Heading { get; set; }

        [Required]
        [AllowHtml]
        public string Description { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Drill" : "New Drill";
            }
        }

        public DrillsFormViewModel()
        {
            Id = 0;
        }
        public DrillsFormViewModel(Drill drill)
        {
            Id = drill.Id;
            Heading = drill.Heading;
            Description = drill.Description;
           
        }
    }
}