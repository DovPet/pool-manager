using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PoolManager.Dtos;
using PoolManager.Models;

namespace PoolManager.Controllers.Api
{
    public class MessageController : ApiController
    {
        private ApplicationDbContext _context;

        public MessageController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<MessageDto> GetMessages()
        {
            return _context.Messages.Include(c => c.MessageTopic).ToList().Select(Mapper.Map<Message, MessageDto>);
        }

        public MessageDto GetMessage(int id)
        {
            var message = _context.Messages.SingleOrDefault(c => c.Id == id);

            if (message == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Message, MessageDto>(message);
        }

        [HttpPost]
        public MessageDto CreateMessage(MessageDto messageDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var message = Mapper.Map<MessageDto, Message>(messageDto);

            _context.Messages.Add(message);
            _context.SaveChanges();

            messageDto.Id = message.Id;

            return messageDto;
        }
       
        [HttpDelete]
        public void DeleteMessage(int id)
        {
            var messageInDb = _context.Messages.SingleOrDefault(c => c.Id == id);
            if (messageInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Messages.Remove(messageInDb);
            _context.SaveChanges();
        }
    }
}
