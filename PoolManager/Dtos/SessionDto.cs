using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PoolManager.Models;

namespace PoolManager.Dtos
{
    public class SessionDto
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Heading { get; set; }
        
        [Required]
        public bool Completed { get; set; }
        
        [Required]
        public int DrillSetId { get; set; }

        [Required]
        [StringLength(128)]
        public string ApplicationUserId { get; set; }
    }
}