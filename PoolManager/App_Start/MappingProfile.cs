using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PoolManager.Dtos;
using PoolManager.Models;

namespace PoolManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Message, MessageDto>();
            Mapper.CreateMap<MessageDto, Message>();
            Mapper.CreateMap<Drill, DrillsDto>();
            Mapper.CreateMap<DrillsDto, Drill>();
        }
    }
}