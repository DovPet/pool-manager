using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoolManager.Dtos
{
    public class DrillsDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Heading { get; set; }

        [Required]
        [AllowHtml]
        public string Description { get; set; }
    }
}