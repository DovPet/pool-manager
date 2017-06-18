using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PoolManager.Dtos;
using PoolManager.Models;

namespace PoolManager.Controllers.Api
{
    public class SessionController : ApiController
    {
        private  ApplicationDbContext _context;
        public SessionController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<SessionDto> GetSessions()
        {
            return _context.Sessions.ToList().Select(Mapper.Map<Session, SessionDto>);
        }

        public SessionDto GetSession(int id)
        {
            var session = _context.Sessions.SingleOrDefault(c => c.Id == id);

            if (session == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Session, SessionDto>(session);
        }

        [HttpPost]
        public SessionDto CreateSession(SessionDto sessionDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var session = Mapper.Map<SessionDto, Session>(sessionDto);

            _context.Sessions.Add(session);
            _context.SaveChanges();

            sessionDto.Id = session.Id;

            return sessionDto;
        }
        [HttpDelete]
        public void DeleteSession(int id)
        {
            var sessionInDb = _context.Sessions.SingleOrDefault(c => c.Id == id);
            if (sessionInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Sessions.Remove(sessionInDb);
            _context.SaveChanges();
        }
    }
}
