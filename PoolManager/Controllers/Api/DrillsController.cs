using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using PoolManager.Dtos;
using PoolManager.Models;

namespace PoolManager.Controllers.Api
{
    public class DrillsController : ApiController
    {

        private ApplicationDbContext _context;

        public DrillsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<DrillsDto> GetDrills()
        {
            return _context.Drills.ToList().Select(Mapper.Map<Drill, DrillsDto>);
        }

        public DrillsDto GetDrill(int id)
        {
            var drill = _context.Drills.SingleOrDefault(c => c.Id == id);

            if (drill == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<Drill, DrillsDto>(drill);
        }

        [HttpPost]
        public DrillsDto CreateDrill(DrillsDto drillsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var drill = Mapper.Map<DrillsDto, Drill>(drillsDto);

            _context.Drills.Add(drill);
            _context.SaveChanges();

            drillsDto.Id = drill.Id;

            return drillsDto;
        }
        [HttpDelete]
        public void DeleteDrill(int id)
        {
            var drillInDb = _context.Drills.SingleOrDefault(c => c.Id == id);
            if (drillInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Drills.Remove(drillInDb);
            _context.SaveChanges();
        }
    }
}
