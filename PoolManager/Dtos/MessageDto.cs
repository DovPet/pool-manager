using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PoolManager.Models;

namespace PoolManager.Dtos
{
    public class MessageDto
    {

        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime? Date { get; set; }

        [Required]
        public int MessageTopicId { get; set; }
    }
}