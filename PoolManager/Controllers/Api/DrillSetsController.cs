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
    public class DrillSetsController : ApiController
    {
        private ApplicationDbContext _context;

        public DrillSetsController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<DrillSetsDto> GetDrillSets()
        {
            return _context.DrillSets.ToList().Select(Mapper.Map<DrillSet, DrillSetsDto>);
        }

        public DrillSetsDto GetDrillSet(int id)
        {
            var drillSet = _context.DrillSets.SingleOrDefault(c => c.Id == id);

            if (drillSet == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Mapper.Map<DrillSet, DrillSetsDto>(drillSet);
        }

        [HttpPost]
        public DrillSetsDto CreateDrillSet(DrillSetsDto drillSetsDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var drillSet = Mapper.Map<DrillSetsDto, DrillSet>(drillSetsDto);

            _context.DrillSets.Add(drillSet);
            _context.SaveChanges();

            drillSetsDto.Id = drillSet.Id;

            return drillSetsDto;
        }
        [HttpDelete]
        public void DeleteDrillSet(int id)
        {
            var drillSetInDb = _context.DrillSets.SingleOrDefault(c => c.Id == id);
            if (drillSetInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.DrillSets.Remove(drillSetInDb);
            _context.SaveChanges();
        }

    }
}
