using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PoolManager.Models;

namespace PoolManager.ViewModels
{

    public class MessageFormViewModel
    {
        DateTime localDate = DateTime.Now;
        public IEnumerable<MessageTopic> MessageTopics { get; set; }
        public int Id { get; set; }

        [Required]
        [AllowHtml]
        public string Text { get; set; }

        public DateTime? Date { get; set; }

        [Required]
        public int MessageTopicId { get; set; }

        public MessageFormViewModel()
        {
            Id = 0;
            Date = localDate;
        }

        public MessageFormViewModel(Message message)
        {
            Id = message.Id;
            Text = message.Text;
            MessageTopicId = message.MessageTopicId;

        }

    }
}