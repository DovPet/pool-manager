using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoolManager.Models
{
    
    public class Message
    {
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        public string Text { get; set; }

        public DateTime? Date { get; set; }

        public MessageTopic MessageTopic { get; set; }

        [Display(Name = "Message Topic")]
        public int MessageTopicId { get; set; }
    }
}