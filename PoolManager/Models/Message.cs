using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PoolManager.Models
{
    public enum MessageTopic
    {
        Drill_problem,
        Technical_problem,
        Suggestion
    }

    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime? Date { get; set; }

        [Required]
        public MessageTopic Topic { get; set; }
    }
}